using UnityEngine;
using System.Collections;

public class basicZombieMovement : MonoBehaviour {

    public float speed = 15.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        //if the zombie reaches the barricade
        if (other.CompareTag("barricade"))
        {
            Debug.Log("collision detected");
            speed = 0;
        }
        //if the zombie is hit with a bullet
        else if (other.CompareTag("bullet"))
        {
            Debug.Log("bullet detected");
            Destroy(gameObject);
        }

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += Vector3.left * speed * Time.deltaTime;
        
    }
}
