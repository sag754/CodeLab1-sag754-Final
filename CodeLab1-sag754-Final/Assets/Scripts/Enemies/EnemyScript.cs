using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float yRange = 10;
    public float speed = 2;
    public float bulletSpeed = 5;
    public int health = 120;
    public int damage = 100;

    public GameObject enemyBullet;
    public GameObject deathEffect;
    public GameObject hitEffect;
    
    public PlayerController target;

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
        if(target != null)
        {
            GameObject newBullet = Instantiate<GameObject>(enemyBullet, transform.position, Quaternion.identity); //create a new bullet prefab
            Vector3 dir = target.transform.position - gameObject.transform.position;
            dir.Normalize();

            newBullet.GetComponent<Rigidbody2D>().velocity = dir * 5;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameManager.gameInstance.points++;
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            PlayerController player = hitInfo.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }

            Instantiate(hitEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}