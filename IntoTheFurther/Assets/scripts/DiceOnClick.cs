using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DiceOnClick : MonoBehaviour {

    const int supplies = 3;
    const int buffOrDebuff = 2;
    const int survivor = 1;

    bool hasRolled;
    bool isRolling;

    public GameObject gameStats;
    public GameObject outcomeText;

    // Use this for initialization
    void Start () {
        gameStats = GameObject.Find("currentGameStats");
        outcomeText = GameObject.Find("outcomeText");
        outcomeText.GetComponent<Text>().text = "";
        hasRolled = false;
     
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnMouseDown()
    {
        if (!hasRolled && !isRolling)
        {
            isRolling = true;
            gameObject.GetComponent<Animator>().Play("DiceRoll");
            Debug.Log("is rolling");
        }
        else if (isRolling)
        {
            hasRolled = true;
            int roll = 0;
            int rnd = Random.Range(0, 100);   // creates a number between 0 and 100
            isRolling = false;

            //10% chance to roll a new survivor
            if (rnd <= 10)
            {
                roll = survivor;
                gameStats.GetComponent<ScenerioAttributes>().numSurvivors += 1;
                gameObject.GetComponent<Animator>().Play("RollOne");
                Debug.Log("rolled a 1");
                outcomeText.GetComponent<Text>().text = "Survivor was found!";
            }
            //30% chance to roll a buff or debuff
            else if (rnd > 10 && rnd <= 40)
            {
                roll = buffOrDebuff;
                gameObject.GetComponent<Animator>().Play("RollTwo");
                outcomeText.GetComponent<Text>().text = "ARGH ZOMBIES!";
                Debug.Log("rolled a 2");
            }
            //60% chance to roll supplies
            else if (rnd > 40 && rnd <= 100)
            {
                gameObject.GetComponent<Animator>().Play("RollThree");
                addSupplies();
                roll = supplies;
                Debug.Log("rolled a 3");
            }

        }
    }

    void addSupplies()
    {
        //decide what supply is generated
        int rnd = Random.Range(1, 3);   // creates a number between 0 and 100

        if (rnd == 3)
        {
            //increase food
            gameStats.GetComponent<ScenerioAttributes>().numFood += 1;
            outcomeText.GetComponent<Text>().text = "searched, and found food!";
        }
        else if (rnd == 2)
        {
            //increase fuel
            gameStats.GetComponent<ScenerioAttributes>().numFuel += 1;
            outcomeText.GetComponent<Text>().text = "searched, and found fuel!";
        }
        else if (rnd == 1)
        {
            //increase water
            gameStats.GetComponent<ScenerioAttributes>().numWater += 1;
            outcomeText.GetComponent<Text>().text = "searched, and found water!";
        }
    }
     
}
