using System.Collections.Generic;

namespace Assets.Scripts.Logic.Repositories.Interfaces
{
    public interface IConfigurationRepository
    {
        IDictionary<string, string> GetAllConfiguration();

        void SetConfiguration(string key, string value);
    }
}