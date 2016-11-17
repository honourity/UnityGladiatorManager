using System.Collections.Generic;
using Assets.Scripts.Logic.DataProviders.Interfaces;
using Assets.Scripts.Logic.Repositories.Interfaces;

namespace Assets.Scripts.Logic.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private static IDataProvider _dataProvider = new Assets.Scripts.Logic.DataProviders.SqliteDataProvider();

        public IDictionary<string, string> GetAllConfiguration()
        {
            var configs = new Dictionary<string, string>();

            string query = "SELECT * FROM Configuration";
            var records = _dataProvider.GetRecords(query);
            foreach (var record in records)
            {
                var config = ConfigFromRecord(record);
                configs[config.Key] = config.Value;
            }

            return configs;
        }

        public void SetConfiguration(string key, string value)
        {
            throw new System.NotImplementedException();
        }

        #region private

        private KeyValuePair<string, string> ConfigFromRecord(IDictionary<string, object> record)
        {
            KeyValuePair<string, string> config;

            if ((record != null) && (record.Count > 0))
            {
                config = new KeyValuePair<string, string>(record["Name"] as string, record["Value"] as string);
            }
            else
            {
                config = new KeyValuePair<string, string>();
            }

            return config;
        }

        #endregion
    }
}
