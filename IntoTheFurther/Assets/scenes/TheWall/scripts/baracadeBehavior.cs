using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class baracadeBehavior : MonoBehaviour {

    public int baracadeHealth;
    public Text healthText;
    public GameObject gameStats;

    // Use this for initialization
    void Start () {
        gameStats = GameObject.Find("currentGameStats");
        //baracdehealth + meds
        baracadeHealth = gameStats.GetComponent<GameStats>().barricadeHealth +
                         gameStats.GetComponent<GameStats>().numMedicine;        
    }
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Barricade Health: " + baracadeHealth;

        //if you lose the barricade
        if(baracadeHealth <= 0)
        {
            SceneManager.LoadScene("ColonyScene");
            gameStats.GetComponent<GameStats>().moral -= 25;
            gameStats.GetComponent<GameStats>().currentDay++;
            gameStats.GetComponent<GameStats>().numDaysLeft--;

            if (gameStats.GetComponent<GameStats>().numSurvivors > 1)
            {
                gameStats.GetComponent<GameStats>().numSurvivors--;
            }
        }

	}

    public void zombieDamage(int damage)
    {
        Debug.Log("barracade damage");
        baracadeHealth -= damage;
    }

}
