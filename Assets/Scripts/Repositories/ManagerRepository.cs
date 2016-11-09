using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System;

public class ManagerRepository
{
    private static SqliteDataProvider _dataProvider = new SqliteDataProvider();

    public IEnumerable<Manager> GetManagers()
    {
        throw new System.NotImplementedException();
    }

    public Manager GetManagerById(long id)
    {
        throw new System.NotImplementedException();
    }

    public Manager GetManagerByName(string name)
    {
        Manager manager = null;

        string query = string.Format("select * from managers where name = '{0}'", name);
        var record = _dataProvider.GetRecord(query);

        if (record.Count > 0)
        {
            manager = new Manager();

            MapDataToModel(manager, record);

            //manager.Id = (long)record["id"];
            //manager.Name = (string)record["name"];

            //since this is stored against gladiators, it wont come from MapDataToModel, also will be ignored when MapDataToModel does a Gladiator
            manager.Gladiators = GetGladiatorsByManagerId(manager.Id);
        }
        
        return manager;
    }

    public IEnumerable<Gladiator> GetGladiators()
    {
        throw new System.NotImplementedException();
    }

    public Gladiator GetGladiatorById(long id)
    {
        throw new System.NotImplementedException();
    }

    public Gladiator GetGladiatorByName(string name)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<Gladiator> GetGladiatorsByManagerId(long id)
    {
        throw new System.NotImplementedException();
    }

    private T MapDataToModel<T>(T model, IDictionary<string, object> data)
    {
        var properties = model.GetType().GetProperties();

        foreach (System.Reflection.PropertyInfo property in properties)
        {
            if (data.ContainsKey(property.Name.ToLower()))
            {
                property.SetValue(model, Convert.ChangeType(data[property.Name.ToLower()], property.PropertyType), null);
            }
        }

        return model;
    }
}

