using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TheColony : MonoBehaviour
{
    bool onStatsPrompt;
    bool diceExist;

    public Text StatsPrompt;
    public Text StatsHUD;
    public Text DicePrompt;
    public Text SearchText;

    public Button returnBtn;
    public Button toWallBtn;

    public GameObject gameStats;
    public GameObject DicePanel;
    public GameObject GlobalOptions;
    public GameObject SearchPanel;

    public GameObject PoliceStation;
    public GameObject Hospital;
    public GameObject School;
    public GameObject GunStore;
    public GameObject DeptStore;
    public GameObject Clinic;
    public GameObject StorageFacility;

    public GameObject Dice;

    public AudioSource[] BGM;
    public AudioSource[] SFX;

    // Use this for initialization
    void Start()
    {
        gameStats = GameObject.Find("currentGameStats");

        diceExist = false;
        //set audio
        GlobalOptions = GameObject.Find("GlobalOptions");
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        BGM[0].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
        //SFX[0].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
        promptStats();
        DicePanel.GetComponent<CanvasGroup>().alpha = 0;
        Dice.GetComponent<SpriteRenderer>().enabled = false;
        PoliceStation.GetComponent<SpriteRenderer>().enabled = false;
        Hospital.GetComponent<SpriteRenderer>().enabled = false;
        School.GetComponent<SpriteRenderer>().enabled = false;
        GunStore.GetComponent<SpriteRenderer>().enabled = false;
        DeptStore.GetComponent<SpriteRenderer>().enabled = false;
        Clinic.GetComponent<SpriteRenderer>().enabled = false;
        StorageFacility.GetComponent<SpriteRenderer>().enabled = false;

        toWallBtn.GetComponent<CanvasGroup>().alpha = 0;
        toWallBtn.GetComponent<Button>().interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        //check if on stats menu, if so wait for space bar to continue
        //and display the small statsHUD
        if (Input.GetKeyUp(KeyCode.Space) && onStatsPrompt)
        {
            StatsPrompt.GetComponent<CanvasGroup>().alpha = 0;
            onStatsPrompt = false;
            displayStatsHUD();
            RollDicePrompt();
        }

        if (Dice.GetComponent<DiceOnClick>().numRollsLeft == 0 && Dice.GetComponent<DiceOnClick>().RollComplete)
        {
            toWallBtn.GetComponent<CanvasGroup>().alpha = 1;
            toWallBtn.GetComponent<Button>().interactable = true;
        }

    }

    void promptStats()
    {
        onStatsPrompt = true;
        StatsPrompt.GetComponent<CanvasGroup>().alpha = 1;

        StatsPrompt.text = ("Current Stats:" +
                             "\n\n\tSurvivors - " + gameStats.GetComponent<GameStats>().numSurvivors +
                             " of " + gameStats.GetComponent<GameStats>().neededSurvivors +
                             "\n\tFuel - " + gameStats.GetComponent<GameStats>().numFuel +
                             " of " + gameStats.GetComponent<GameStats>().neededFuel +
                             "\n\tFood - " + gameStats.GetComponent<GameStats>().numFood +
                             " of " + gameStats.GetComponent<GameStats>().neededFood +
                             "\n\tWater - " + gameStats.GetComponent<GameStats>().numWater +
                             " of " + gameStats.GetComponent<GameStats>().neededWater +
                             "\n\tDays Left - " + gameStats.GetComponent<GameStats>().numDaysLeft +
                             "\n\n Press Space to Continue");

    }

    void displayStatsHUD()
    {
        StatsHUD.GetComponent<CanvasGroup>().alpha = 1;
        StatsHUD.text = ("Current Stats:" +
                             "\n\n\tSurvivors - " + gameStats.GetComponent<GameStats>().numSurvivors +
                             " of " + gameStats.GetComponent<GameStats>().neededSurvivors +
                             "\n\tFuel - " + gameStats.GetComponent<GameStats>().numFuel +
                             " of " + gameStats.GetComponent<GameStats>().neededFuel +
                             "\n\tFood - " + gameStats.GetComponent<GameStats>().numFood +
                             " of " + gameStats.GetComponent<GameStats>().neededFood +
                             "\n\tWater - " + gameStats.GetComponent<GameStats>().numWater +
                             " of " + gameStats.GetComponent<GameStats>().neededWater +
                             "\n\tDays Left - " + gameStats.GetComponent<GameStats>().numDaysLeft);
    }

    void RollDicePrompt()
    {
        DicePanel.GetComponent<CanvasGroup>().alpha = 1;
        Dice.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void returnOnClick()
    {
        //back to menu
        //hide all the searchableItems
        SearchPanel.GetComponent<CanvasGroup>().alpha = 0;
        returnBtn.GetComponent<CanvasGroup>().alpha = 0;

        PoliceStation.GetComponent<SpriteRenderer>().enabled = false;
        Hospital.GetComponent<SpriteRenderer>().enabled = false;
        School.GetComponent<SpriteRenderer>().enabled = false;
        GunStore.GetComponent<SpriteRenderer>().enabled = false;
        DeptStore.GetComponent<SpriteRenderer>().enabled = false;
        Clinic.GetComponent<SpriteRenderer>().enabled = false;
        StorageFacility.GetComponent<SpriteRenderer>().enabled = false;

        displayStatsHUD();
        RollDicePrompt();
        Dice.GetComponent<DiceOnClick>().RollComplete = true;
    }

    public void DisplaySearch()
    {
        PoliceStation.GetComponent<SpriteRenderer>().enabled = true;
        Hospital.GetComponent<SpriteRenderer>().enabled = true;
        School.GetComponent<SpriteRenderer>().enabled = true;
        GunStore.GetComponent<SpriteRenderer>().enabled = true;
        DeptStore.GetComponent<SpriteRenderer>().enabled = true;
        Clinic.GetComponent<SpriteRenderer>().enabled = true;
        StorageFacility.GetComponent<SpriteRenderer>().enabled = true;

        SearchPanel.GetComponent<CanvasGroup>().alpha = 1;

        //Hide others
        StatsHUD.GetComponent<CanvasGroup>().alpha = 0;
        DicePanel.GetComponent<CanvasGroup>().alpha = 0;
        Dice.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void ToTheWallOnClick()
    {
        SceneManager.LoadScene("TheWallScene");
    }

}
