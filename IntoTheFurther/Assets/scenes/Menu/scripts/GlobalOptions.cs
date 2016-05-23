using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalOptions : MonoBehaviour
{

    public float volume;

    //make sure volume is set when the new scene is loaded
    //void OnLevelWasLoaded()
    //{
    //    AudioListener.volume = PlayerPrefs.GetFloat("volume");
    //    DontDestroyOnLoad(gameObject);
    //}

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        DontDestroyOnLoad(gameObject);        
    }

    void Update()
    {
        volume = PlayerPrefs.GetFloat("volume");
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }


}
