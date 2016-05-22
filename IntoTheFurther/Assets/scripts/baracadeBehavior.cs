using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class baracadeBehavior : MonoBehaviour {

    public int baracadeHealth;
    public Text healthText;


    // Use this for initialization
    void Start () {
        baracadeHealth = 100;        
    }
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Barricade Health: " + baracadeHealth;

        if(baracadeHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

	}

    public void zombieDamage(int damage)
    {
        Debug.Log("barracade damage");
        baracadeHealth -= damage;
    }

}
