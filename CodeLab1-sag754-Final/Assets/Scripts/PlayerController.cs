using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveForward;
    public KeyCode moveBack;

    public float health = 1;

    public BaseWeapon attack;

    // Start is called before the first frame update
    void Start()
    {
        attack = GetComponent<BaseWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        }

        if (Input.GetKey(moveForward))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
        }

        if (Input.GetKey(moveDown))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        }

        if (Input.GetKey(moveBack))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            attack.Shoot();
        }

        if((!Input.GetKey(moveUp) && !Input.GetKey(moveDown) && !Input.GetKey(moveForward) && !Input.GetKey(moveBack)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    //private void OnCollisionEnter2D(Collision collision)
    //{
       // if(collision.gameObject.name.Contains("Bullet"))
       // {
           // Destroy(collision.gameObject);
          //  TakeDamage(20);
       // }
   // }

    public void TakeDamage(float damageAmt)
    {
        health -= damageAmt;
    }
}
