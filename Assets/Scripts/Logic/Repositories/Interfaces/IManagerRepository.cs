using System.Collections.Generic;
using Assets.Scripts.Logic.Models;

namespace Assets.Scripts.Logic.Repositories.Interfaces
{
    public interface IManagerRepository
    {
        IEnumerable<Manager> GetManagers();

        Manager GetManagerById(long id);

        Manager GetManagerByName(string name);

        Manager NewPlayerManager();

        Manager NewManager(int rating);
    }
}
