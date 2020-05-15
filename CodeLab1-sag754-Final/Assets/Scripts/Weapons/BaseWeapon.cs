using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firepoint;
    public GameObject bulletPrefab;

    public virtual void Shoot()
    {

        var countOfExistingBullets = GameObject.FindGameObjectsWithTag("Bullet").Length;
        if (countOfExistingBullets < 3 && Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
    }
}
