using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TheWall : MonoBehaviour
{
    public Camera cam;
    public GameObject GlobalOptions;
    public AudioSource[] BGM;
    public AudioSource[] SFX;

    public GameObject gameStats;
    public GameObject EnemyFormation;
    public GameObject[] spawnerQuads;

    void Start()
    {
        GlobalOptions = GameObject.Find("GlobalOptions");
        gameStats = GameObject.Find("currentGameStats");
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        BGM[0].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
        for (int i = 0; i < SFX.Length; i++)
            SFX[i].volume = GlobalOptions.GetComponent<GlobalOptions>().volume;
        //assign the counter
        gameStats.GetComponent<GameStats>().zombieSpawnedCount = gameStats.GetComponent<GameStats>().numZombies;
        SpawnRoundZombies();
           

    }

    void Update()
    {
        if (gameStats.GetComponent<GameStats>().numZombies == 0)
        {
            gameStats.GetComponent<GameStats>().currentDay++;
            gameStats.GetComponent<GameStats>().numDaysLeft--;
            SceneManager.LoadScene("ColonyScene");
        }
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
        int dayNum = gameStats.GetComponent<GameStats>().currentDay;

        float yPos = -2;
        float xPos = 25;
        float zPos = -5;
        
        //instantiate as many spawner quads as there are current days
        for (int i = 0; i < dayNum; i++)
        {            
            //spawnerQuad position vector
            Vector3 spawnderQuad = new Vector3(xPos, yPos, zPos);

            //instantiate and assign the spawner quad
            spawnerQuads[i] = Instantiate(EnemyFormation, spawnderQuad, Quaternion.identity) as GameObject;
            xPos += 30;
        }

        //spawn zombie positions
        for (int i = 0; i < dayNum; i++)
        {
            int usedZombies = 0;
            usedZombies = spawnerQuads[i].GetComponent<EnemySpawner>().setZombiePositions(gameStats.GetComponent<GameStats>().zombieSpawnedCount);
            gameStats.GetComponent<GameStats>().zombieSpawnedCount -= usedZombies;
        }

        //check if all zombies were used
        while (gameStats.GetComponent<GameStats>().zombieSpawnedCount != 0)
        {
            int usedZombies = 0;
            int rndQuad = Random.Range(0, dayNum - 1);
            usedZombies = spawnerQuads[rndQuad].GetComponent<EnemySpawner>().setZombiePositions(gameStats.GetComponent<GameStats>().zombieSpawnedCount);
            gameStats.GetComponent<GameStats>().zombieSpawnedCount -= usedZombies;
        }

        //spawn zombies in the cells
        for (int i = 0; i < dayNum; i++)
        {
            spawnerQuads[i].GetComponent<EnemySpawner>().spawnZombies(spawnerQuads[i].transform.position);
        }

    }

    public void AbandonClicked()
    {
        gameStats.GetComponent<GameStats>().moral -= 10;
        gameStats.GetComponent<GameStats>().currentDay++;
        gameStats.GetComponent<GameStats>().numDaysLeft--;
        SceneManager.LoadScene("ColonyScene");
    }

}
