using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTriple : PowerUpBase
{
    public override void Updgrade(GameObject player)
    {
        Destroy(player.GetComponent<BaseWeapon>());
        Destroy(player.GetComponent<LaserShot>());
        Destroy(player.GetComponent<SpreadShot>());
        TripleShot triple = player.AddComponent<TripleShot>();
        triple.firepoint = player.GetComponent<PlayerController>().firePoint.transform;
        triple.bulletPrefab = player.GetComponent<PlayerController>().bulletPrefab;
        player.GetComponent<PlayerController>().attack = triple;
    }
}
