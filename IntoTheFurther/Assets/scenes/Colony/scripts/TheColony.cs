using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TheColony : MonoBehaviour {
       
    public Text StatsPrompt;
    public Text StatsHUD;
    public Text DicePrompt;

    public GameObject gameStats;

    public GameObject DicePanel;

    bool onStatsPrompt;

	// Use this for initialization
	void Start () {
        //make sure running totals stays intact
        DontDestroyOnLoad(gameStats);
        promptStats();
        DicePanel.GetComponent<CanvasGroup>().alpha = 0;
    }
	
	// Update is called once per frame
	void Update () {

        //check if on stats menu, if so wait for space bar to continue
        //and display the small statsHUD
        if (Input.GetKeyUp(KeyCode.Space) && onStatsPrompt)
        {
            StatsPrompt.GetComponent<CanvasGroup>().alpha = 0;
            onStatsPrompt = false;
            displayStatsHUD();
            RollDicePrompt();
        }


    }

    void promptStats()
    {
        onStatsPrompt = true;
        StatsPrompt.GetComponent<CanvasGroup>().alpha = 1;

        StatsPrompt.text = ("Current Stats:" +
                             "\n\n\tSurvivors - " + gameStats.GetComponent<ScenerioAttributes>().numSurvivors +
                             " of " + gameStats.GetComponent<ScenerioAttributes>().neededSurvivors +
                             "\n\tFuel - " + gameStats.GetComponent<ScenerioAttributes>().numFuel +
                             " of " + gameStats.GetComponent<ScenerioAttributes>().neededFuel +
                             "\n\tFood - " + gameStats.GetComponent<ScenerioAttributes>().numFood +
                             " of " + gameStats.GetComponent<ScenerioAttributes>().neededFood +
                             "\n\tWater - " + gameStats.GetComponent<ScenerioAttributes>().numWater +
                             " of " + gameStats.GetComponent<ScenerioAttributes>().neededWater +
                             "\n\tDays Left - " + gameStats.GetComponent<ScenerioAttributes>().numDaysLeft +
                             "\n\n Press Space to Continue");    

    }

    void displayStatsHUD()
    {
        StatsHUD.GetComponent<CanvasGroup>().alpha = 1;
        StatsHUD.text = ("Current Stats:" +
                             "\n\n\tSurvivors - " + gameStats.GetComponent<ScenerioAttributes>().numSurvivors +
                             " of " + gameStats.GetComponent<ScenerioAttributes>().neededSurvivors +
                             "\n\tFuel - " + gameStats.GetComponent<ScenerioAttributes>().numFuel +
                             " of " + gameStats.GetComponent<ScenerioAttributes>().neededFuel +
                             "\n\tFood - " + gameStats.GetComponent<ScenerioAttributes>().numFood +
                             " of " + gameStats.GetComponent<ScenerioAttributes>().neededFood +
                             "\n\tWater - " + gameStats.GetComponent<ScenerioAttributes>().numWater +
                             " of " + gameStats.GetComponent<ScenerioAttributes>().neededWater +
                             "\n\tDays Left - " + gameStats.GetComponent<ScenerioAttributes>().numDaysLeft);                             
    }

    void RollDicePrompt()
    {
        DicePanel.GetComponent<CanvasGroup>().alpha = 1;
        DicePanel.GetComponent<DicePlayMechanics>().SpawnDice();
    }

}
