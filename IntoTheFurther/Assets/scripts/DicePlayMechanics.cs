using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DicePlayMechanics : MonoBehaviour
{

    const int supplies = 3;
    const int buffOrDebuff = 2;
    const int survivor = 1;

    bool hasRolled;
    bool isRolling;
    public GameObject Dice;
    public GameObject gameStats;

    public GameObject[] DiceSpawners;

    // Use this for initialization
    void Start()
    {
        //assign all dice spawners
        for (int i = 0; i < 10; i++)
        {
            DiceSpawners[i] = GameObject.Find("DiceSpawner" + (i+1));
        }

        gameStats = GameObject.Find("currentGameStats");
     
        hasRolled = false;       
    }

    public void SpawnDice()
    {
        //for every survivor spawn a dice objects
        for (int i = 0; i < gameStats.GetComponent<ScenerioAttributes>().numSurvivors; i++)
        {
            Debug.Log("Dice" + i + "has been spawned!");
            Instantiate(Dice, DiceSpawners[i].transform.position, Quaternion.identity);
        }
    }

}
