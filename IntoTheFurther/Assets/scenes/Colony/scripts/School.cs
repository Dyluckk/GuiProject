using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class School : MonoBehaviour {

    public Text OutcomeText;
    public Text popUpSearchText;

    public GameObject SearchChancesPanel;
    public GameObject OutcomePanel;

    public GameObject gameStats;
    public GameObject hourGlass;
    public GameObject UIBlocker;
    public GameObject returnButton;

    //bool thinking;

    void Start()
    {
        gameStats = GameObject.Find("currentGameStats");
    }

    public void OnMouseOver()
    {
        //make visible
        SearchChancesPanel.GetComponent<CanvasGroup>().alpha = 1;

        //show text
        popUpSearchText.text = "School:\n\n" +
                               "Medicine - 10%\n" +
                               "Fuel - 30%\n" +
                               "Water - 25%\n" +
                               "Food - 20%\n" +
                               "Survivors 5%\n" +
                               "\nRisk - 40%";
    }


    public void OnMouseExit()
    {
        //hide panel
        SearchChancesPanel.GetComponent<CanvasGroup>().alpha = 0;

        //remove text
        popUpSearchText.text = "";
    }


    public void OnMouseDown()
    {
        //prompt a are you sure?
        SearchChancesPanel.GetComponent<CanvasGroup>().alpha = 0;
        OutcomePanel.GetComponent<CanvasGroup>().alpha = 1;
        OutcomeText.text = "";
        hourGlass.GetComponent<SpriteRenderer>().enabled = true;

        StartCoroutine(DecideOutcome());
        UIBlocker.GetComponent<BoxCollider2D>().enabled = true;

    }

    IEnumerator DecideOutcome()
    {
        int rndSearch = Random.Range(0, 100);
        int rndRisk = Random.Range(0, 100);

        float timer = 2.0f;
        hourGlass.GetComponent<Animator>().Play("hourglassAnim");

        while (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        //hourGlass.GetComponent<Animator>().Stop();
        hourGlass.GetComponent<SpriteRenderer>().enabled = false;
        //render the hourglass and loop animation for a few seconds         

        returnButton.GetComponent<Button>().interactable = true;
        returnButton.GetComponent<CanvasGroup>().alpha = 1;

        //hide hourglass
        // hourGlass.GetComponent<SpriteRenderer>().enabled = false;

        //check if risk was activated
        if (rndRisk >= 40)
        {
            //if risk wasn't activated proceed to search
            if (rndSearch <= 10)
            {
                //medicine found
                int foundMed = Random.Range(1, 2);
                gameStats.GetComponent<GameStats>().numMedicine += foundMed;

                OutcomeText.text = "Search Successful:\n" +
                                   "\n\nFound " + foundMed + " medical supplies";


            }
            else if (rndSearch <= 20)
            {
                //fuel found
                int rndAmmo = Random.Range(1, 20);
                gameStats.GetComponent<GameStats>().pistolAmmo += rndAmmo;

                OutcomeText.text = "Search Successful:\n" +
                                   "\n\nFound " + rndAmmo + " Pistol Ammo";

            }
            else if (rndSearch <= 45)
            {
                //water found
                int foundWater = Random.Range(1, 2);
                gameStats.GetComponent<GameStats>().numWater += foundWater;

                OutcomeText.text = "Search Successful:\n" +
                                   "\n\nFound " + foundWater + " Water";
            }
            else if (rndSearch <= 70)
            {
                //food found
                int foundFood = Random.Range(1, 2);
                gameStats.GetComponent<GameStats>().numFood += foundFood;

                OutcomeText.text = "Search Successful:\n" +
                                   "\n\nFound " + foundFood + " Food";
            }
            else if (rndSearch <= 95)
            {
                //food found
                int foundFuel = Random.Range(1, 2);
                gameStats.GetComponent<GameStats>().numFuel += foundFuel;

                OutcomeText.text = "Search Successful:\n" +
                                   "\n\nFound " + foundFuel + " Fuel";
            }
            else if (rndSearch <= 100)
            {
                //survior found
                gameStats.GetComponent<GameStats>().numSurvivors += 1;

                OutcomeText.text = "Search Successful:\n" +
                                   "\n\nFound " + 1 + " Survivor";
            }


        }
        else
        {
            //set text to fail
            rndRisk = Random.Range(0, 100);

            if (rndRisk < 50)
            {
                //rndm chance for moral to drop
                gameStats.GetComponent<GameStats>().moral -= 1;

                OutcomeText.text = "Search Fail:\n" +
                                   "\n\nMoral " + "-1";
            }
            else if (rndRisk < 70)
            {
                //rndm chance for death of a survivor
                if ((gameStats.GetComponent<GameStats>().numSurvivors != 1))
                {
                    gameStats.GetComponent<GameStats>().numSurvivors -= 1;

                    OutcomeText.text = "Search Fail:\n" +
                                       "\n\nA member of the search party died in the process " +
                                       "\n-1" + " Survivor";
                }
                else
                {
                    //if only 1 survivor do nothing
                    OutcomeText.text = "Search Fail:\n" +
                                     "\n\nYour search party found nothing ";

                }

            }
            else if (rndRisk < 100)
            {
                //rndm chance for nothing to happen
                OutcomeText.text = "Search Fail:\n" +
                                   "Your search party found nothing ";
            }
        }


    }


}
