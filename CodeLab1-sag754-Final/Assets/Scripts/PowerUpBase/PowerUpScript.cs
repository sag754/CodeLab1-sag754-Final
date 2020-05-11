using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    Vector2 startPos;
    PowerUpBase[] powers;
    // Start is called before the first frame update
    void Start()
    {
        powers = GetComponents<PowerUpBase>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitObj = collision.gameObject;
        if (hitObj.name.Equals("Player"))
        { //if the powerUp hit the ship
            int randomPower = Random.Range(0, powers.Length);
            powers[randomPower].Updgrade(hitObj); //give the ship a random powerUp
        }

        transform.position = startPos; //reset to startPos
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; //remove velocity
    }
}
