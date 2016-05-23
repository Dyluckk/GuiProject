using UnityEngine;
using System.Collections;

public class ScenerioAttributes : MonoBehaviour{

    public int neededSurvivors;
    public int neededFood;
    public int neededFuel;
    public int neededWater;

    public int numFuel;
    public int numFood;
    public int numWater;
    public int numSurvivors;
    public int numDaysLeft;

    //list of buffs and debuffs
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 0));        
    }

    void Start()
    {     
        neededSurvivors = 3;
        neededFood = 10;
        neededWater = 20;
        neededFuel = 30;
        
        //player counts as a survivor
        numSurvivors = 1;
        numDaysLeft = 40;
    }
    


}
    
