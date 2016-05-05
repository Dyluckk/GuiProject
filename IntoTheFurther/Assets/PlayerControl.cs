using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float speed = 15.0f;
    public GameObject projectile;
    float yMax = 0f;
    float yMin = -4.5f;
    public float projectileSpeed = 1;
    public float fireRate = 1;
    
    void Start() {
          
    }

    void Fire()
    {
        gameObject.GetComponent<AudioSource>().Play();
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileSpeed, 0, 0);          
    }
    
    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", .0000001f, fireRate);
          
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

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
