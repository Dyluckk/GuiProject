using UnityEngine;
using System.Collections;

public class diceSpawner : MonoBehaviour {

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
