using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : BaseWeapon
{
    public override void Shoot()
    {
        Instantiate(bulletPrefab, firepoint.position + new Vector3(.2f, .1f, 0f), Quaternion.Euler(0f, 0f, 45f));
        Instantiate(bulletPrefab, firepoint.position + new Vector3(.5f, .1f, 0f), Quaternion.Euler(0f, 0f, 22f));
        Instantiate(bulletPrefab, firepoint.position + new Vector3(.2f, 0f, 0f), firepoint.rotation);
        Instantiate(bulletPrefab, firepoint.position + new Vector3(.5f, -.1f, 0f), Quaternion.Euler(0f, 0f, -22f));
        Instantiate(bulletPrefab, firepoint.position + new Vector3(.2f, -.1f, 0f), Quaternion.Euler(0f, 0f, -45f));
    }
}
