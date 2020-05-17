using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveForward;
    public KeyCode moveBack;
    public GameObject firePoint;
    public GameObject laserPrefab;
    public GameObject bulletPrefab;
    public GameObject deathEffect;
    public AudioSource audioSource;
    public int moveX = 5;
    public int moveY = 5;
    public Text objective;

    public float health = 1;
    public static int points = 0;

    public BaseWeapon attack;
    public static PlayerController playerInstance;

    // Start is called before the first frame update
    void Start()
    {
        //set up the singleton
        if (playerInstance == null)
        { //if instance isn't set
            playerInstance = this; //set it to this instance
            DontDestroyOnLoad(gameObject); //Don't destory this gameObject
        }
        else
        { //otherwise, if we have a singleton already
            Destroy(gameObject); //Destroy this instance
        }

        attack = GetComponent<BaseWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveY);
        }

        if (Input.GetKey(moveForward))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, 0);
        }

        if (Input.GetKey(moveDown))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -moveY);
        }

        if (Input.GetKey(moveBack))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveX, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            attack.Shoot();
        }

        if((!Input.GetKey(moveUp) && !Input.GetKey(moveDown) && !Input.GetKey(moveForward) && !Input.GetKey(moveBack)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }


        objective.text = "DEFEAT: 50  /  " + PlayerController.points;

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "PowerUp")
        { //if the powerUp hit the shi
            audioSource.Play();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
