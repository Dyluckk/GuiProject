using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TheColony : MonoBehaviour {

    int numFuel;
    int numFood;
    int numWater;
    int numSurvivors;
    int numDaysLeft;
    
    public Text StatsPrompt;
    public Text StatsHUD;
    public Text DicePrompt;

    bool onStatsPrompt;

	// Use this for initialization
	void Start () {
        promptStats();
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
                             "\n\n\tSurvivors - " + numSurvivors +
                             "\n\tFuel - " + numFuel +
                             "\n\tFood - " + numFood +
                             "\n\tWater - " + numWater +
                             "\n\tDays Left - " + numDaysLeft +
                             "\n\n Press Space to Continue");    

    }

    void displayStatsHUD()
    {
        StatsHUD.GetComponent<CanvasGroup>().alpha = 1;
        StatsHUD.text = ("Current Stats:" +
                             "\n\n\tSurvivors - " + numSurvivors +
                             "\n\tFuel - " + numFuel +
                             "\n\tFood - " + numFood +
                             "\n\tWater - " + numWater +
                             "\n\tDays Left - " + numDaysLeft);
    }

    void RollDicePrompt()
    {

    }

}
