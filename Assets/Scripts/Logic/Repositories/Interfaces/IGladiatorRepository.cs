using System.Collections.Generic;
using Assets.Scripts.Logic.Models;

namespace Assets.Scripts.Logic.Repositories.Interfaces
{
    public interface IGladiatorRepository
    {
        IEnumerable<Gladiator> GetGladiators();

        Gladiator GetGladiatorById(long id);

        Gladiator GetGladiatorByName(string name);

        IEnumerable<Gladiator> GetGladiatorsByManagerId(long id);

        IEnumerable<Gladiator> GetStarterGladiators();

        Gladiator NewPlayerGladiator();

        Gladiator NewRandomGladiator(int rating);
    }
}
