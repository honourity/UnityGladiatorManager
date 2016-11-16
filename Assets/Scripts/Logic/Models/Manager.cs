using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Logic.Models
{
    public class Manager
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Gladiator> Gladiators { get; set; }

        public Gladiator SelfGladiator { get { return Gladiators.FirstOrDefault(g => g.IsPlayer); } }
    }
}