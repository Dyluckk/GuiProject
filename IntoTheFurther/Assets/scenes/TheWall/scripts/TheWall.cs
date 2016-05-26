using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TheWall : MonoBehaviour
{
    public Camera cam;
    public GameObject GlobalOptions;
    public AudioSource[] BGM;
    public AudioSource[] SFX;

    public GameObject gameStats;
    public GameObject[] spawnerQuad;
    public GameObject basicZombiePosition;


    
    void Start()
    {
        GlobalOptions = GameObject.Find("GlobalOptions");
        gameStats = GameObject.Find("currentGameStats");
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        BGM[0].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
        for(int i = 0; i < SFX.Length; i++)
        SFX[i].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;

        SpawnRoundZombies();              
    }

    void OnDrawGizmos()
    {

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }

    void SpawnRoundZombies()
    {
        
    }

}
