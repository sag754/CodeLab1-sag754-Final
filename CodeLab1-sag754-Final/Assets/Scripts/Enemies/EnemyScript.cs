using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float yRange = 10;
    public float speed = 2;
    public float bulletSpeed = 5;
    public int health = 120;
    public GameObject enemyBullet;
    public GameObject deathEffect;
    
    public PlayerController target;
    Vector2 aimDirection;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 1, 3); //call "Fire" every second
        Reset();
    }

    public void Reset()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        transform.position = new Vector2(10f, Random.Range(-yRange, yRange));

        rb.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10)
        {
            EnemyPool.instance.Push(gameObject);
        }
    }

    void Fire()
    {
        //Instantiate<GameObject>(enemyBullet);
        //target = GameObject.FindObjectOfType<PlayerController>();
        //aimDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        //rb.velocity = new Vector2(aimDirection.x, aimDirection.y)
        

        if(target != null)
        {
            GameObject newBullet = Instantiate<GameObject>(enemyBullet, transform.position, Quaternion.identity); //create a new bullet prefab
            Vector3 dir = target.transform.position - gameObject.transform.position;
            dir.Normalize();

            newBullet.GetComponent<Rigidbody2D>().velocity = dir * 5;
        }
        //Vector2 newPos = transform.position;
        //newPos.x -= 0.7f;
        //newBullet.transform.position = newPos; //put the bullet below the enem
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}