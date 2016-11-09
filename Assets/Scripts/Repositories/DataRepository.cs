using System;
using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.DataProviders.Interfaces;

namespace Assets.Scripts.Repositories
{
    public class DataRepository
    {
        private static IDataProvider _dataProvider = new Assets.Scripts.DataProviders.SqliteDataProvider();

        public IEnumerable<Manager> GetManagers()
        {
            List<Manager> managers = new List<Manager>();

            string query = "SELECT * FROM Managers";
            var records = _dataProvider.GetRecords(query);
            foreach (var record in records)
            {
                managers.Add(ManagerFromRecord(record));
            }

            return managers;
        }

        public Manager GetManagerById(long id)
        {
            string query = string.Format("SELECT * FROM Managers WHERE Id = '{0}'", id);
            var record = _dataProvider.GetRecord(query);
            return ManagerFromRecord(record);
        }

        public Manager GetManagerByName(string name)
        {
            string query = string.Format("SELECT * FROM Managers WHERE Name = '{0}'", name);
            var record = _dataProvider.GetRecord(query);
            return ManagerFromRecord(record);
        }

        public IEnumerable<Gladiator> GetGladiators()
        {
            List<Gladiator> gladiators = new List<Gladiator>();

            string query = "SELECT * FROM Gladiators";
            var records = _dataProvider.GetRecords(query);
            foreach (var record in records)
            {
                gladiators.Add(GladiatorFromRecord(record));
            }

            return gladiators;
        }

        public Gladiator GetGladiatorById(long id)
        {
            string query = string.Format("SELECT * FROM Gladiators WHERE Id = '{0}'", id);
            var record = _dataProvider.GetRecord(query);
            return GladiatorFromRecord(record);
        }

        public Gladiator GetGladiatorByName(string name)
        {
            string query = string.Format("SELECT * FROM Gladiators WHERE Name = '{0}'", name);
            var record = _dataProvider.GetRecord(query);
            return GladiatorFromRecord(record);
        }

        public IEnumerable<Gladiator> GetGladiatorsByManagerId(long id)
        {
            List<Gladiator> gladiators = new List<Gladiator>();

            string query = string.Format("SELECT * FROM Gladiators WHERE FK_Manager_Id = '{0}'", id);
            var records = _dataProvider.GetRecords(query);
            foreach (var record in records)
            {
                gladiators.Add(GladiatorFromRecord(record));
            }

            return gladiators;
        }

        #region private
        private Manager ManagerFromRecord(IDictionary<string, object> record)
        {
            Manager manager = null;

            if ((record != null) && (record.Count > 0))
            {
                manager = new Manager();

                MapDataToModel(manager, record);

                //wont come from generic MapDataToModel, also will be ignored when MapDataToModel does a Gladiator
                manager.Gladiators = GetGladiatorsByManagerId(manager.Id);
            }

            return manager;
        }

        private Gladiator GladiatorFromRecord(IDictionary<string, object> record)
        {
            Gladiator gladiator = null;

            if ((record != null) && (record.Count > 0))
            {
                gladiator = new Gladiator();

                MapDataToModel(gladiator, record);
            }

            return gladiator;
        }

        private void MapDataToModel<T>(T model, IDictionary<string, object> data)
        {
            var properties = model.GetType().GetProperties();

            foreach (System.Reflection.PropertyInfo property in properties)
            {
                if (data.ContainsKey(property.Name.ToLower()))
                {
                    property.SetValue(model, Convert.ChangeType(data[property.Name], property.PropertyType), null);
                }
            }
        }
        #endregion
    }
}