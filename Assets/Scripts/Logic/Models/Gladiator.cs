using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Logic.Models
{
    public class Gladiator
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long? ManagerId { get; set; }

        public bool IsManager { get; set; }
    }
}
