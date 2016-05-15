using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePreferences : MonoBehaviour {

    public GameObject volumeSlider;
    public float volume;

	// Use this for initialization
	void Start () {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        volumeSlider.GetComponent<Slider>().value = AudioListener.volume;
	}
	
	// Update is called once per frame
	void Update () {
        volume = volumeSlider.GetComponent<Slider>().value;
    }

    public void changeVolume()
    {
        AudioListener.volume = (volumeSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        PlayerPrefs.Save();
    }
}
