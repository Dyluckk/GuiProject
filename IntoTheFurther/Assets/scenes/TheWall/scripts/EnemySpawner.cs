using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject zombiePos;
    public float width = 25f;
    public float height = 5.5f;
    public GameObject GmStats;

    public List<Vector3> ZombiePosList;
    public float ZombieSpacing;

	// Use this for initialization
	void Start () {
        GmStats = GameObject.Find("currentGameStats");
        ZombiePosList = new List<Vector3>();
        ZombieSpacing = .5f;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void spawnZombies(Vector3 quad_pos)
    {
        //foreach (Transform child in transform)
        //{
        //    GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
        //    enemy.transform.SetParent(child);
        //    //enemy.transform.parent = child;
        //}

        foreach (Vector3 pos in ZombiePosList)
        {
            Instantiate(enemyPrefab, quad_pos + pos, Quaternion.identity);
        }
    }

    public int setZombiePositions(int zombieSpawn)
    {
        int zombieLimit = 30;
        //int zombieTotal = GmStats.GetComponent<GameStats>().zombieSpawnedCount;
        int zombieTotal = zombieSpawn;
        //spawn a random amount between 1 and 30 in the zombie containers
        int rndZombieDropAmount = Random.Range(1, zombieLimit);

        //make sure there isn't more zombies being spawned than total
        if (rndZombieDropAmount > zombieTotal)
        {
            rndZombieDropAmount = Random.Range(1, zombieTotal);
        }
                
        //bounds for spawning in box
        float yUppberBound = height/2;
        float yLowerBound = -(height)/2;

        float xLeftBound = -(width)/2;
        float xRightBound = width/2;

        float zPos = 0;

        float rndX = Random.Range(xLeftBound, xRightBound);
        float rndY = Random.Range(yLowerBound, yUppberBound);

        //spawn a random amount between 1 and 30 in the zombie containers
        for (int i = 0; i < rndZombieDropAmount; i++)
        {
            Vector3 zombiePosVector = Vector3.zero;

            bool spotFound = false;
            int tries = 10;
            while (!spotFound && tries > 0)
            {
                rndX = Random.Range(xLeftBound, xRightBound);
                rndY = Random.Range(yLowerBound, yUppberBound);
                zombiePosVector = new Vector3(rndX, rndY, zPos);

                foreach (Vector3 vec in ZombiePosList)
                {
                    if (Vector3.Distance(zombiePosVector, vec) <= ZombieSpacing)
                        break;

                    spotFound = true;
                }

                tries--;
            }

            ZombiePosList.Add(zombiePosVector);
        }

        foreach (Vector3 vec in ZombiePosList)
        {
            //instantiate and assign the spawner quad
            var newSpawn = Instantiate(zombiePos);
            newSpawn.transform.SetParent(transform);
            newSpawn.transform.localPosition = vec;
        }

        //subtracts from the drop amount
        //GmStats.GetComponent<GameStats>().zombieSpawnedCount -= rndZombieDropAmount;
        return rndZombieDropAmount;
    }
}
