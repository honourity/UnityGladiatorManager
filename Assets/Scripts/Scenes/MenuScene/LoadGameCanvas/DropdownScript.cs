using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

namespace Assets.Scripts.Scenes.MenuScene.LoadGameCanvas
{
    public class DropdownScript : MonoBehaviour
    {
        public Button LoadGameButton;

        // Use this for initialization
        protected void Start()
        {
            var options = GameController.ManagerRepository.GetPlayerManagers().Select(manager => manager.Name).ToList();
            if (options.Count > 0)
            {
                gameObject.GetComponent<Dropdown>().AddOptions(options);
            }
            else
            {
                LoadGameButton.enabled = false;
            }
        }
    }
}

