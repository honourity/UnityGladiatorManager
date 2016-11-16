using UnityEngine;
using Assets.Scripts.Logic.Repositories;
using Assets.Scripts.Logic.Models;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        //store all the things
        public static GameController gameController;

        private static ManagerRepository _managerRepository = new ManagerRepository();

        protected void Awake()
        {
            Object.DontDestroyOnLoad(gameObject);
            gameController = this;
        }

        // Use this for initialization
        void Start()
        {
            //show a welcome screen with choice between loading existing game or making new game
            // new game screen has a bunch of fields for name and stats
            // load game screen has a list of player managers to choose from
            //attempt to load a game, and setup gamestate based on loaded data
            // set scene based on whichever scene game was at when saved (might only be able to save at a specific point anyway)

            //all scenes TBD
            // - newgame
            // - loadgame
            // - choose first gladiator
            // - market to buy gladiators
            // - billboard to enter tournaments
            // - tournament event itself
            // - manage existing gladiators
            // - various story-related dialogue panels
            // - view your own stats

            //_managerRepository.GetManagerByName("Tom");
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