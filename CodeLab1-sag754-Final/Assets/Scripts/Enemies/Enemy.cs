using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 120;
    public Vector3 initVelocity = new Vector3(1, 0, 0);
    private Rigidbody2D rb;
    public float minX = 10;

    public GameObject enemyBullet;

    public GameObject deathEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initVelocity;
        InvokeRepeating("Fire", 1, 1); //call "Fire" every second
    }

    private void Update()
    {
        if(transform.position.x < minX)
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Fire()
    {
        GameObject newBullet = Instantiate<GameObject>(enemyBullet); //create a new bullet prefab
        Vector2 newPos = transform.position;
        newPos.x -= 0f;
        newBullet.transform.position = newPos; //put the bullet below the enemy
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        } 
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
