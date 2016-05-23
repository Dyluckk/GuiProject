using UnityEngine;
using System.Collections;

public class TheWall : MonoBehaviour {

    public Camera cam;
    public GameObject GlobalOptions;
    public AudioSource[] BGM;
    public AudioSource[] SFX;

    void Start()
    {
        GlobalOptions = GameObject.Find("GlobalOptions");
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        BGM[0].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
        SFX[0].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
    }

    void OnDrawGizmos()
    {

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }
}
