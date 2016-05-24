using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenerioSelect : MonoBehaviour
{
    public GameObject gameStats;
    public Text promptScenerio;
    public AudioSource[] BGM;
    public AudioSource[] SFX;
    public GameObject GlobalOptions;

    // Use this for initialization
    void Start()
    {
        //DontDestroyOnLoad(gameStats);
        scenerioPromt();
        GlobalOptions = GameObject.Find("GlobalOptions");
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        BGM[0].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
        //SFX[0].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void scenerioPromt()
    {
        promptScenerio.text = ("Scenerio: Escape:" +
                              "\n\nSurvivors Needed - " + gameStats.GetComponent<GameStats>().neededSurvivors +
                              "\nFuel Needed - " + gameStats.GetComponent<GameStats>().neededFuel +
                              "\nFood Needed - " + gameStats.GetComponent<GameStats>().neededFood +
                              "\nWater Needed - " + gameStats.GetComponent<GameStats>().neededWater +
                              "\nDays To Complete - " + gameStats.GetComponent<GameStats>().numDaysLeft);
    }

    public void continueOnClick()
    {
        SceneManager.LoadScene("ColonyScene");
    }

}
