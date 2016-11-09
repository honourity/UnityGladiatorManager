using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Text;
using Assets.Scripts.DataProviders.Interfaces;

namespace Assets.Scripts.DataProviders
{
    public class SqliteDataProvider : IDataProvider
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

        public void UpsertRecord(string table, IDictionary<string, object> record)
        {
            var updateQuery = new StringBuilder();
            updateQuery.Append("update ");
            updateQuery.Append(table);
            updateQuery.Append(" set ");
            foreach (var field in record)
            {
                if (field.Value == null)
                {
                    updateQuery.Append(field.Key);
                    updateQuery.Append("=null");
                }
                else if (field.Value.GetType() == typeof(string))
                {
                    updateQuery.Append(field.Key);
                    updateQuery.Append("='");
                    updateQuery.Append(field.Value.ToString());
                    updateQuery.Append("'");
                }
                else if (field.Value.GetType() == typeof(bool))
                {
                    updateQuery.Append(field.Key);
                    updateQuery.Append("=");
                    updateQuery.Append(((bool)field.Value) ? "1" : "0");
                }
                else
                {
                    updateQuery.Append(field.Key);
                    updateQuery.Append("=");
                    updateQuery.Append(field.Value.ToString());
                }

                updateQuery.Append(", ");
            }
            updateQuery.Remove(updateQuery.Length - 2, 2);
            updateQuery.Append(" where ");
            updateQuery.Append( "Id = ");
            updateQuery.Append(record["Id"]);

            var changes = (int)ExecuteScalar(updateQuery.ToString());

            if (changes <= 0)
            {
                var insertQuery = new StringBuilder();
                insertQuery.Append("insert into ");
                insertQuery.Append(table);
                insertQuery.Append(" (");

                foreach (var field in record)
                {
                    insertQuery.Append(field.Key);
                    insertQuery.Append(", ");
                }
                insertQuery.Remove(insertQuery.Length - 2, 2);
                insertQuery.Append(") ");

                insertQuery.Append("values (");
                foreach (var field in record)
                {
                    if (field.Value == null)
                    {
                        insertQuery.Append("null");
                    }
                    else if (field.Value.GetType() == typeof(string))
                    {
                        insertQuery.Append("'");
                        insertQuery.Append(field.Value.ToString());
                        insertQuery.Append("'");
                    }
                    else
                    {
                        insertQuery.Append(field.Value.ToString());
                    }

                    insertQuery.Append(", ");
                }
                insertQuery.Remove(insertQuery.Length - 2, 2);
                insertQuery.Append(");");

                ExecuteScalar(insertQuery.ToString());
            }
        }

        public void DeleteRecord(string table, long id)
        {
            StringBuilder query = new StringBuilder();

            query.Append("delete from ");
            query.Append(table);
            query.Append(" where Id = ");
            query.Append(id);

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

        private object ExecuteScalar(string query)
        {
            object result = null;

            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query.ToString();
                    result = command.ExecuteScalar();
                }

                connection.Close();
            }

            return result;
        }
    }
}