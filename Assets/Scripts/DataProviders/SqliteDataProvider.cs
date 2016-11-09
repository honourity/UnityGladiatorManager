using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Text;

public class SqliteDataProvider
{
    private static string connectionString = "URI=file:" + Application.dataPath + "/Data/datastore.sqlite";

    public IDictionary<string, object> GetRecord(string query)
    {
        var record = new Dictionary<string, object>();

        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            record[reader.GetName(i)] = reader.GetValue(i);
                        }
                    }
                }
            }

            connection.Close();
        }

        return record;
    }

    public IEnumerable<Dictionary<string, object>> GetRecords(string query)
    {
        var records = new List<Dictionary<string, object>>();

        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var rowDictionary = new Dictionary<string, object>();
                        
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rowDictionary[reader.GetName(i)] = reader.GetValue(i);
                        }

                        records.Add(rowDictionary);
                    }
                }
            }

            connection.Close();
        }

        return records;
    }

    public void UpsertRecord(string table, object[] record)
    {
        StringBuilder query = new StringBuilder();

        query.Append("insert into ");
        query.Append(table);
        query.Append(" values(");

        foreach (object field in record)
        {
            if (field == null)
            {
                query.Append("null");
            }
            else if (field.GetType() == typeof(string))
            {
                query.Append("'");
                query.Append(field.ToString());
                query.Append("'");
            }
            else
            {
                query.Append(field.ToString());
            }

            query.Append(", ");
        }

        query.Remove(query.Length - 2, 2);
        query.Append(");");

        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query.ToString();
                command.ExecuteScalar();
            }

            connection.Close();
        }
    }

    public void UpsertRecords(string table, object[][] records)
    {
        StringBuilder query = new StringBuilder();

        foreach (object[] record in records)
        {
            query.Append("insert into ");
            query.Append(table);
            query.Append(" values(");

            foreach (object field in record)
            {
                if (field == null)
                {
                    query.Append("null");
                }
                else if (field.GetType() == typeof(string))
                {
                    query.Append("'");
                    query.Append(field.ToString());
                    query.Append("'");
                }
                else
                {
                    query.Append(field.ToString());
                }

                query.Append(", ");
            }

            query.Remove(query.Length - 2, 2);
            query.Append(");");
        }

        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query.ToString();
                command.ExecuteScalar();
            }

            connection.Close();
        }
    }

    public void DeleteRecord(string table, int id)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteRecords(string table, int[] id)
    {
        throw new System.NotImplementedException();
    }
}
