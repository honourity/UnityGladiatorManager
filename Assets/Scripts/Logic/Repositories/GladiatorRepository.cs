using System;
using System.Collections.Generic;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.DataProviders.Interfaces;
using Assets.Scripts.Logic.Helpers;
using Assets.Scripts.Logic.Repositories.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Logic.Repositories
{
    public class GladiatorRepository : IGladiatorRepository
    {
        private static IDataProvider _dataProvider = new Assets.Scripts.Logic.DataProviders.SqliteDataProvider();

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
            var gladiators = new List<Gladiator>();

            string query = string.Format("SELECT * FROM Gladiators WHERE ManagerId = '{0}'", id);
            var records = _dataProvider.GetRecords(query);
            foreach (var record in records)
            {
                gladiators.Add(GladiatorFromRecord(record));
            }

            return gladiators;
        }

        public IEnumerable<Gladiator> GetStarterGladiators()
        {
            throw new NotImplementedException();
        }

        public Gladiator NewPlayerGladiator()
        {
            throw new NotImplementedException();
        }

        public Gladiator NewRandomGladiator(Int32 rating)
        {
            throw new NotImplementedException();
        }

        #region private

        private Gladiator GladiatorFromRecord(IDictionary<string, object> record)
        {
            Gladiator gladiator = null;

            if ((record != null) && (record.Count > 0))
            {
                gladiator = new Gladiator();

                DataHelper.MapDataToModel(gladiator, record);
            }

            return gladiator;
        }

        #endregion
    }
}