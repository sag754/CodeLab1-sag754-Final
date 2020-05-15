using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : BaseWeapon
{
    public override void Shoot()
    {

        var countOfExistingBullets = GameObject.FindGameObjectsWithTag("Bullet").Length;
        if (countOfExistingBullets < 1 && Input.GetMouseButtonDown(0))
        {
            Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        }
    }
}
