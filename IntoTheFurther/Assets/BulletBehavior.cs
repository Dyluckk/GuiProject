using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bulletShredder"))
        {
            Debug.Log("bullet destroyed");
            Destroy(gameObject);
        }
    }
}
