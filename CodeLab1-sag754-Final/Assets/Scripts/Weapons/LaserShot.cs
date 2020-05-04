using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : BaseWeapon
{
    public override void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
