using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Logic.Models
{
    public class Manager
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Gladiator> Gladiators { get; set; }

        //figure out how to cast GameObject or define it better
        public Gladiator ManagerGladiator { get { return Gladiators.FirstOrDefault(g => g.IsManager); } }
    }
}