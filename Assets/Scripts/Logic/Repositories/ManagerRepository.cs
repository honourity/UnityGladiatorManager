using System.Collections.Generic;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.DataProviders.Interfaces;
using Assets.Scripts.Logic.Helpers;
using Assets.Scripts.Logic.Repositories.Interfaces;
using System;
using System.Linq;

namespace Assets.Scripts.Logic.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        private static IDataProvider _dataProvider = new Assets.Scripts.Logic.DataProviders.SqliteDataProvider();
        private static IGladiatorRepository _gladiatorRepository = new GladiatorRepository();

        public IEnumerable<Manager> GetManagers()
        {
            var managers = new List<Manager>();

            string query = "SELECT * FROM Managers";
            var records = _dataProvider.GetRecords(query);
            foreach (var record in records)
            {
                managers.Add(GetManagerFromRecord(record));
                
            }

            return managers;
        }

        public IEnumerable<Manager> GetPlayerManagers()
        {
            var managers = GetManagers().Where(manager => manager.ManagerGladiator != null);
            return managers;
        }

        public Manager GetManagerById(long id)
        {
            string query = string.Format("SELECT * FROM Managers WHERE Id = '{0}'", id);
            var record = _dataProvider.GetRecord(query);
            return GetManagerFromRecord(record);
        }

        public Manager GetManagerByName(string name)
        {
            string query = string.Format("SELECT * FROM Managers WHERE Name = '{0}'", name);
            var record = _dataProvider.GetRecord(query);
            return GetManagerFromRecord(record);
        }

        public Manager NewPlayerManager()
        {
            throw new NotImplementedException();
        }

        public Manager NewManager(int rating)
        {
            throw new NotImplementedException();
        }

        #region private

        private Manager GetManagerFromRecord(IDictionary<string,object> record)
        {
            var manager = DataHelper.CreateModelFromData<Manager>(record);

            if (manager != null)
            {
                //wont come from generic MapDataToModel, also will be ignored when MapDataToModel does a Gladiator
                manager.Gladiators = _gladiatorRepository.GetGladiatorsByManagerId(manager.Id);
            }

            return manager;
        }

        #endregion
    }
}