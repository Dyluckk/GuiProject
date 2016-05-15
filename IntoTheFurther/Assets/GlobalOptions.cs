using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalOptions : MonoBehaviour {

    public float volume;
    public Slider volumeSlider;

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        volumeSlider.GetComponent<Slider>().value = AudioListener.volume;

    }

    void Update()
    {
        volume = volumeSlider.GetComponent<Slider>().value;
        //AudioListener.volume = (volumeSlider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(20, 20, 1));
    }

    
}
