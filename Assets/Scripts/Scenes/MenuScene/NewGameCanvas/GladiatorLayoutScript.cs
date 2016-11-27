using UnityEngine;
using Assets.Scripts.Prefabs;

namespace Assets.Scripts.Scenes.MenuScene.NewGameCanvas
{
    public class GladiatorLayoutScript : MonoBehaviour
    {
        public GameObject GladiatorPrefab;

        // Use this for initialization
        void Start()
        {
            var gladiators = GameController.GladiatorRepository.GetStarterGladiators();
            foreach (var gladiator in gladiators)
            {
                var gladiatorPrefabClone = Instantiate(GladiatorPrefab) as GameObject;
                gladiatorPrefabClone.GetComponent<GladiatorPrefabScript>().Gladiator = gladiator;
                gladiatorPrefabClone.transform.SetParent(gameObject.transform, false);
            }
        }
    }
}
