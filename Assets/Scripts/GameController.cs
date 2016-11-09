using UnityEngine;
using Assets.Scripts.Repositories;
using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        //store all the things
        public static GameController gameController;

        private static DataRepository _managerRepository = new DataRepository();

        protected void Awake()
        {
            Object.DontDestroyOnLoad(gameObject);
            gameController = this;
        }

        // Use this for initialization
        void Start()
        {
            _managerRepository.GetManagerByName("Tom");
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected void OnDestroy()
        {
            gameController = null;
        }
    }
}