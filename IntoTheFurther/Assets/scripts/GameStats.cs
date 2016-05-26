using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour{

    public int neededSurvivors;
    public int neededFood;
    public int neededFuel;
    public int neededWater;

    public int numFuel;
    public int numFood;
    public int numWater;
    public int numSurvivors;
    public int numDaysLeft;
    public int moral;

    public int currentDay;
    public int pistolAmmo;
    public int numZombies;

    //list of buffs and debuffs
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 0));        
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        neededSurvivors = 3;
        neededFood = 10;
        neededWater = 20;
        neededFuel = 30;
        
        //player counts as a survivor
        numSurvivors = 1;
        numDaysLeft = 40;

        moral = 100;
        pistolAmmo = 100;

        numZombies = 30;
        currentDay = 1;

    }
    


}
    
