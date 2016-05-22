using UnityEngine;
using System.Collections;

public class DiceOnClick : MonoBehaviour {

    const int supplies = 3;
    const int buffOrDebuff = 2;
    const int survivor = 1;

    bool hasRolled;
    bool isRolling;
    public GameObject Dice;

	// Use this for initialization
	void Start () {
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
                gameObject.GetComponent<Animator>().Play("RollOne");
                Debug.Log("rolled a 1");
            }
            //30% chance to roll a buff or debuff
            else if (rnd > 10 && rnd <= 40)
            {
                roll = buffOrDebuff;
                gameObject.GetComponent<Animator>().Play("RollTwo");
                Debug.Log("rolled a 2");
            }
            //60% chance to roll supplies
            else if (rnd > 40 && rnd <= 100)
            {
                gameObject.GetComponent<Animator>().Play("RollThree");
                roll = supplies;
                Debug.Log("rolled a 3");
            }


            //add to stats
        }
    }
    
}
