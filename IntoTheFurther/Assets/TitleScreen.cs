/***********************************************************************************
*   Author:         Zachary Wentworth
*   Version:        TitleScreen v.0.0.1
*   Last Modified:  4/13/16
*
*   Recent Modifications:
*       -Canvas groups used to hide buttons
*       -Camera ends animation if space is pressed
*          
*
************************************************************************************/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleScreen : MonoBehaviour {

    private float _timeLeft = 20;
    private bool menuIsUp = false;
    public Text title;
    public Button startButton;
    public Button aboutButton;

    public Text aboutText;
    public Text startText;
    public GameObject TitleZombie;

    public Animator cameraAnim;

    // Use this for initialization
    void Start () {

        aboutText.text = "";

        TitleZombie.SetActive(false);
        title.GetComponent < CanvasGroup >().alpha = 0;
        startButton.GetComponent<CanvasGroup>().alpha = 0;
        aboutButton.GetComponent<CanvasGroup>().alpha = 0;       
    }
	
	// Update is called once per frame
	void Update () {

        //subtract deltaTime until the timer runs out
        if (_timeLeft > 0 && menuIsUp == false)
        {
            _timeLeft -= Time.deltaTime;
            print(_timeLeft);
        }
        
        //once the timer has ran out make title and menu buttons available
        if ((_timeLeft < 0 || Input.GetKeyDown(KeyCode.Space)) && (menuIsUp == false))
        {
            title.GetComponent<CanvasGroup>().alpha = 1;
            startButton.GetComponent<CanvasGroup>().alpha = 1;
            aboutButton.GetComponent<CanvasGroup>().alpha = 1;
            TitleZombie.SetActive(true);
            cameraAnim.Update(20);
            menuIsUp = true;
            print("Time Complete");
        }
                       
    }

    public void AboutClicked() {
        //buttons dissapear
        startButton.GetComponent<CanvasGroup>().alpha = 0;
        aboutButton.GetComponent<CanvasGroup>().alpha = 0;

        Vector3 pos = TitleZombie.transform.position;
        Vector3 oldPos = TitleZombie.transform.position;
        oldPos.x = 749;
        pos.x = 1000;

        TitleZombie.transform.position = pos;
  
        //text is displayed
        aboutText.text = "Welcome to Into The Further...\n" +
                       "This turn based zombie survival game is currently in developement\n" +
                       "These details will change soon!\n\n" +
                       "PRESS \"Space\" TO RETURN TO THE MAIN MENU";

        //if space is pressed re-enable buttons, sprites and remove about text
        if (Input.GetKeyDown(KeyCode.Space))
        {
            aboutText.text = "";
            startButton.GetComponent<CanvasGroup>().alpha = 1;
            aboutButton.GetComponent<CanvasGroup>().alpha = 1;
            TitleZombie.transform.position = oldPos;    
        }
    }

    public void StartClicked() {
        //buttons dissapear
        startButton.GetComponent<CanvasGroup>().alpha = 0;
        aboutButton.GetComponent<CanvasGroup>().alpha = 0;

        Vector3 pos = TitleZombie.transform.position;
        Vector3 oldPos = TitleZombie.transform.position;
        oldPos.x = 749;
        pos.x = 1000;

        TitleZombie.transform.position = pos;

        //text is displayed
        aboutText.text = "Coming Soon...\n\n" +
                         "PRESS \"Space\" TO RETURN TO THE MAIN MENU";

        //if space is pressed re-enable buttons, sprites and remove about text
        if (Input.GetKeyDown(KeyCode.Space))
        {
            aboutText.text = "";
            startButton.GetComponent<CanvasGroup>().alpha = 1;
            aboutButton.GetComponent<CanvasGroup>().alpha = 1;
            TitleZombie.transform.position = oldPos;
        }
    }

}
