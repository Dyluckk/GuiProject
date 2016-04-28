using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed = 15.0f;
    float yMax = 0f;
    float yMin = -4.5f;

    void Start() {
          
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.position += new Vector3(0, +speed * Time.deltaTime, 0);
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        //restrict player to game space
        float newY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

}
