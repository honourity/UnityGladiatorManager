using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

namespace Assets.Scripts
{
    public class LoadGameDropdown : MonoBehaviour
    {
        // Use this for initialization
        protected void Start()
        {
            gameObject.GetComponent<Dropdown>().AddOptions(GameController.ManagerRepository.GetPlayerManagers().Select(manager => manager.Name).ToList());
        }
    }
}

