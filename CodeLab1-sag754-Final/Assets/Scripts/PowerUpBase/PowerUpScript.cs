using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    Vector2 startPos;
    PowerUpBase power;
    public float yRange = 1;
    public float speed = 2;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        power = GetComponent<PowerUpBase>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(startPos, transform.position) > 20)
        {
            transform.position = startPos;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        
    }

    public void Reset()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        transform.position = new Vector2(10,
            Random.Range(-yRange, yRange));

        rb.velocity = Vector2.left * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObj = collision.gameObject;
        if (hitObj.name.Equals("Player"))
        { //if the powerUp hit the shi
            power.Updgrade(hitObj); //give the ship a random powerUp

            Destroy(gameObject);
        } 
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
