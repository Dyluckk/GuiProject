using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiceOnClick : MonoBehaviour
{
    const int search = 3;
    const int buffOrDebuff = 2;
    const int survivor = 1;
    bool isRolling;
    public int numRollsLeft;
    int roll;
    public bool RollComplete;

    public GameObject gameStats;
   
    public GameObject TheColonyController;

    public Text rollsLeftText;
    public Text outcomeText;

    public Button outcomeBtn;   


    // Use this for initialization
    void Start()
    {
        gameStats = GameObject.Find("currentGameStats");
        TheColonyController = GameObject.Find("Main Camera");

        outcomeText.text = "";
        numRollsLeft = gameStats.GetComponent<GameStats>().numSurvivors;
        outcomeBtn.GetComponent<CanvasGroup>().alpha = 0;
        outcomeBtn.GetComponent<Button>().interactable = false;
        RollComplete = false;
        rollsLeftText.text = "Rolls Left: " + numRollsLeft; 
    }

    // Update is called once per frame
    void Update()
    {
        if(numRollsLeft == 0 && (outcomeBtn.GetComponent<Button>().interactable != true))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
           
            rollsLeftText.GetComponent<CanvasGroup>().alpha = 0;
        }

        if (numRollsLeft > 0)
        {
            RollComplete = false;
        }
    }

    public void OnMouseDown()
    {
        if (!isRolling && (numRollsLeft > 0))
        {
            isRolling = true;
            gameObject.GetComponent<Animator>().Play("DiceRoll");
            Debug.Log("is rolling");
            //decrement rolls
            
        }
        else if (isRolling)
        {
            outcomeBtn.GetComponent<Button>().interactable = true;
            numRollsLeft--;
            roll = 0;

            gameObject.GetComponent<AudioSource>().Play();

            int rnd = Random.Range(0, 100);   // creates a number between 0 and 100
            isRolling = false;

            //10% chance to roll a new survivor
            if (rnd <= 10)
            {
                roll = survivor;
                gameStats.GetComponent<GameStats>().numSurvivors += 1;
                gameObject.GetComponent<Animator>().Play("RollOne");
                Debug.Log("rolled a 1");
                outcomeText.text = "Survivor was found!";
                outcomeBtn.GetComponent<CanvasGroup>().alpha = 1;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            //30% chance to roll a buff or debuff
            else if (rnd > 10 && rnd <= 40)
            {
                roll = buffOrDebuff;
                gameObject.GetComponent<Animator>().Play("RollTwo");
                outcomeText.text = "ARGH ZOMBIES!";
                Debug.Log("rolled a 2");
                outcomeBtn.GetComponent<CanvasGroup>().alpha = 1;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            //60% chance to roll supplies
            else if (rnd > 40 && rnd <= 100)
            {
                gameObject.GetComponent<Animator>().Play("RollThree");
                outcomeText.text = "SEARCH!!!";
                roll = search;
                Debug.Log("rolled a 3");
                outcomeBtn.GetComponent<CanvasGroup>().alpha = 1;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void outcomeBtnOnClick()
    {

        if (roll == search)
        {
            //go to search
            TheColonyController.GetComponent<TheColony>().DisplaySearch();
        }
        else if (roll == buffOrDebuff)
        {
            //something will happen here regarding buffs and debuffs
            RollComplete = true;
        }
        else if (roll == survivor)
        {
            RollComplete = true;
            //something with survivors will happen
        }

        rollsLeftText.text = "Rolls Left: " + numRollsLeft;

        gameObject.GetComponent<BoxCollider2D>().enabled = true;

        outcomeBtn.GetComponent<CanvasGroup>().alpha = 0;
        outcomeBtn.GetComponent<Button>().interactable = false;

        outcomeText.text = "";       
    }

}
