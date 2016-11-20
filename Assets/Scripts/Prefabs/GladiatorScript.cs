using UnityEngine;
using System.Collections;
using Assets.Scripts.Logic.Models;
using System.Linq;

namespace Assets.Scripts.Prefabs
{
    public class GladiatorScript : MonoBehaviour
    {
        private Gladiator _gladiator;

        public void SetGladiator(Gladiator gladiator)
        {
            _gladiator = gladiator;
        }
    }
}
