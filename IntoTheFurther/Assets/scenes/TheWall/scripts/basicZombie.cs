using UnityEngine;
using System.Collections;

public class basicZombie : MonoBehaviour {

    public float MovementSpeed = 1.0f;
    public float AttackSpeedTimer = 1f;
    public int damage = 1;
    public GameObject Barricade;
    //public GameObject BloodSplatter;
    //public Animator BloodSplatterAnimator;
    public GameObject gameStats;
    bool isAttacking;
    int health;


    void OnTriggerEnter2D(Collider2D other)
    {
        //if the zombie is hit with a bullet
        if (other.CompareTag("bullet"))
        {
           // GameObject blood = Instantiate(BloodSplatter, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            health--;
            Destroy(other.gameObject);
            Debug.Log("bullet hit zombie");

            //if (!(blood.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("bloodAnim")))
            //    {
            //        Destroy(blood);
            //    }
        } 
        //if the zombie reaches the barricade
        if (other.CompareTag("barricade"))
        {
            //if collision with barricade
            Debug.Log("collision detected");
            MovementSpeed = 0;

            isAttacking = true;
        }
    }

    // Use this for initialization
    void Start () {
        isAttacking = false;
        Barricade = GameObject.Find("Barricade");
        gameStats = GameObject.Find("currentGameStats");
        health = 2;
    }
	
	// Update is called once per frame
	void Update () {

        //moves the zombie
        transform.position += Vector3.left * MovementSpeed * Time.deltaTime;

        if (isAttacking)
        {
            AttackSpeedTimer -= Time.deltaTime;
        }

        if (isAttacking && (AttackSpeedTimer < 0))
        {
            //subtract barricade health based on if touching barricade and Attack Speed
            Barricade.GetComponent<baracadeBehavior>().zombieDamage(damage);
            Debug.Log("zombie attack");
            AttackSpeedTimer = 1f;
        }

        if (health == 0)
        {
            gameStats.GetComponent<GameStats>().numZombies--;
            Destroy(gameObject);
        }

    }
}
