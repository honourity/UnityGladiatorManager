using System.Collections.Generic;

namespace Assets.Scripts.Logic.DataProviders.Interfaces
{
    public interface IDataProvider
    {
        IDictionary<string, object> GetRecord(string query);

        IEnumerable<Dictionary<string, object>> GetRecords(string query);

        void UpsertRecord(string table, IDictionary<string, object> record);

        void DeleteRecord(string table, long id);
    }
}
