using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 120;
    public Vector3 initVelocity = new Vector3(-10, 0, 0);
    private Rigidbody2D rb;
    public float minX = 2;

    public GameObject deathEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = initVelocity;
    }

    private void Update()
    {
        if(transform.position.x < minX)
        {
            rb.velocity = Vector3.zero;
        }
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
}
