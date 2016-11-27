using UnityEngine;
using Assets.Scripts.Logic.Repositories;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Repositories.Interfaces;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        //store all the things
        public static GameController gameController;

        //pretend this is dependency injection
        public static IConfigurationRepository ConfigurationRepository;
        public static IManagerRepository ManagerRepository;
        public static IGladiatorRepository GladiatorRepository;

        public static GameState GameState;

        public UnityEngine.UI.Text LoadGameDropdownText;

        public void LoadGame()
        {
            GameState.Player = ManagerRepository.GetManagerByName(LoadGameDropdownText.text);
            GameState.Config = ConfigurationRepository.GetAllConfiguration();

            SceneManager.LoadScene("Game Scene");
        }

        public void NewGame()
        {
            //todo - setManager new manager
            //todo - create gamestate configuration and save to database
            //_gameState.Player = ManagerRepository.GetManagerByName(LoadGameDropdownText.text);
            //_gameState.Config = ConfigurationRepository.GetAllConfiguration();

            SceneManager.LoadScene("Game Scene");
        }

        protected void Awake()
        {
            Object.DontDestroyOnLoad(gameObject);
            gameController = this;

            ConfigurationRepository = new ConfigurationRepository();
            ManagerRepository = new ManagerRepository();
            GladiatorRepository = new GladiatorRepository();

            GameState = new GameState();
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