using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScenerioStartScreen : MonoBehaviour {

    public GameObject gameStats;
    public Text promptScenerio;

    // Use this for initialization
    void Start () {
        //DontDestroyOnLoad(gameStats);
        scenerioPromt();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void scenerioPromt()
    {
       promptScenerio.text = ("Scenerio: Escape:" +
                             "\n\n\tSurvivors Needed - " +  gameStats.GetComponent<ScenerioAttributes>().neededSurvivors +
                             "\n\tFuel Needed - " + gameStats.GetComponent<ScenerioAttributes>().neededFuel +
                             "\n\tFood Needed - " + gameStats.GetComponent<ScenerioAttributes>().neededFood +
                             "\n\tWater Needed - " + gameStats.GetComponent<ScenerioAttributes>().neededWater +
                             "\n\tDays To Complete - " + gameStats.GetComponent<ScenerioAttributes>().numDaysLeft +
                             "\n\n Press Space to Continue");
    }
}
