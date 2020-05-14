using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpLaser : PowerUpBase
{
    public override void Updgrade(GameObject player)
    {
        Destroy(player.GetComponent<BaseWeapon>());
        Destroy(player.GetComponent<TripleShot>());
        Destroy(player.GetComponent<SpreadShot>());
        LaserShot laser = player.AddComponent<LaserShot>();
        laser.firepoint = player.GetComponent<PlayerController>().firePoint.transform;
        laser.bulletPrefab = player.GetComponent<PlayerController>().laserPrefab;
        player.GetComponent<PlayerController>().attack = laser;
    }
}
