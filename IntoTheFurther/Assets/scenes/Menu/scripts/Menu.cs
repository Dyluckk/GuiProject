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
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private float _timeLeft = 20;
    private bool menuIsUp = false;
    public float volume;

    public Button startButton;
    public Button aboutButton;
    public Button optionsButton;
    public Button backButton;

    public Text title;
    public Text aboutText;
    public Text volText;

    public GameObject TitleZombie;
    public GameObject BGM;

    public Slider volSlider;

    public Animator cameraAnim;

    public Slider volumeSlider;


    // Use this for initialization
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        volumeSlider.GetComponent<Slider>().value = AudioListener.volume;

        aboutText.text = "";
        volText.text = "";

        TitleZombie.SetActive(false);

        title.GetComponent<CanvasGroup>().alpha = 0;
        startButton.GetComponent<CanvasGroup>().alpha = 0;
        aboutButton.GetComponent<CanvasGroup>().alpha = 0;
        optionsButton.GetComponent<CanvasGroup>().alpha = 0;
        backButton.GetComponent<CanvasGroup>().alpha = 0;

        volSlider.GetComponent<Slider>().interactable = false;
        volSlider.GetComponent<CanvasGroup>().alpha = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //get the volume from player prefs
        volume = volumeSlider.GetComponent<Slider>().value;
        AudioListener.volume = (volumeSlider.GetComponent<Slider>().value);
        //save the volume setting
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();

        BGM.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");

        //subtract deltaTime until the timer runs out
        if (_timeLeft > 0 && menuIsUp == false)
        {
            _timeLeft -= Time.deltaTime;
        }

        //once the timer has ran out make title and menu buttons available
        if ((_timeLeft < 0 || Input.anyKey) && (menuIsUp == false))
        {
            title.GetComponent<CanvasGroup>().alpha = 1;
            startButton.GetComponent<CanvasGroup>().alpha = 1;
            aboutButton.GetComponent<CanvasGroup>().alpha = 1;
            optionsButton.GetComponent<CanvasGroup>().alpha = 1;
            //change this to a sprite render
            TitleZombie.SetActive(true);
            cameraAnim.Update(20);
            menuIsUp = true;
        }

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    TitleZombie.GetComponent<Animator>().Play("brownchange");
        //}
    }

    public void AboutClicked()
    {
        //buttons dissapear
        startButton.GetComponent<CanvasGroup>().alpha = 0;
        aboutButton.GetComponent<CanvasGroup>().alpha = 0;
        optionsButton.GetComponent<CanvasGroup>().alpha = 0;

        startButton.GetComponent<Button>().interactable = false;
        aboutButton.GetComponent<Button>().interactable = false;
        optionsButton.GetComponent<Button>().interactable = false;

        backButton.GetComponent<CanvasGroup>().alpha = 1;

        //change this to a sprite render
        Vector3 pos = TitleZombie.transform.position;
        Vector3 oldPos = TitleZombie.transform.position;
        oldPos.x = 749;
        pos.x = 2000;

        TitleZombie.transform.position = pos;

        //text is displayed
        aboutText.text = "Welcome to Into The Further...\n" +
                         "This strategy shooter zombie survival game is currently in developement\n" +
                         "These details will change soon!\n\n";
    }

    public void StartClicked()
    {
        SceneManager.LoadScene("ScenerioSelectScene");
    }

    public void OptionsClicked()
    {
        volText.text = "Volume";
        volSlider.GetComponent<Slider>().interactable = true;
        volSlider.GetComponent<CanvasGroup>().alpha = 1;
        backButton.GetComponent<CanvasGroup>().alpha = 1;

        //hide buttons
        startButton.GetComponent<CanvasGroup>().alpha = 0;
        aboutButton.GetComponent<CanvasGroup>().alpha = 0;
        optionsButton.GetComponent<CanvasGroup>().alpha = 0;

        startButton.GetComponent<Button>().interactable = false;
        aboutButton.GetComponent<Button>().interactable = false;
        optionsButton.GetComponent<Button>().interactable = false;

        //change this to a sprite render
        Vector3 pos = TitleZombie.transform.position;
        Vector3 oldPos = TitleZombie.transform.position;
        oldPos.x = 749;
        pos.x = 1000;
    }

    public void BackClicked()
    {
        //change this to a sprite render
        Vector3 oldPos = TitleZombie.transform.position;
        oldPos.x = 749;

        //reset menu UI
        aboutText.text = "";
        volText.text = "";
        startButton.GetComponent<CanvasGroup>().alpha = 1;
        aboutButton.GetComponent<CanvasGroup>().alpha = 1;
        optionsButton.GetComponent<CanvasGroup>().alpha = 1;
        TitleZombie.transform.position = oldPos;

        startButton.GetComponent<Button>().interactable = true;
        aboutButton.GetComponent<Button>().interactable = true;
        optionsButton.GetComponent<Button>().interactable = true;

        volSlider.GetComponent<Slider>().interactable = false;
        volSlider.GetComponent<CanvasGroup>().alpha = 0;

        backButton.GetComponent<CanvasGroup>().alpha = 0;
    }
}
