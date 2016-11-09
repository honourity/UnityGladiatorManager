using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    //store all the things
    public static GameController gameController;

    private static ManagerRepository _managerRepository = new ManagerRepository();

    protected void Awake()
    {
        Object.DontDestroyOnLoad(gameObject);
        gameController = this;
    }

	// Use this for initialization
	void Start () {
        _managerRepository.GetManagerByName("Tom");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void OnDestroy()
    {
        gameController = null;
    }
}
