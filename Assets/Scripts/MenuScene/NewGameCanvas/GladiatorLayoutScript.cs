using UnityEngine;
using Assets.Scripts.Prefabs;

namespace Assets.Scripts.MenuScene.NewGameCanvas
{
    public class GladiatorLayoutScript : MonoBehaviour
    {
        public GameObject GladiatorPrefab;

        // Use this for initialization
        void Start()
        {
            GladiatorPrefab = Resources.Load("GladiatorPrefab") as GameObject;

            var gladiators = GameController.GladiatorRepository.GetStarterGladiators();
            foreach (var gladiator in gladiators)
            {
                var gladiatorPrefabClone = Instantiate(GladiatorPrefab) as GameObject;
                gladiatorPrefabClone.GetComponent<GladiatorScript>().SetGladiator(gladiator);
                gladiatorPrefabClone.transform.SetParent(gameObject.transform, false);
            }
        }
    }
}
