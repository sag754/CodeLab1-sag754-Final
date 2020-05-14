using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpread : PowerUpBase
{
    // Start is called before the first frame update
    public override void Updgrade(GameObject player)
    {
        Destroy(player.GetComponent<BaseWeapon>());
        Destroy(player.GetComponent<LaserShot>());
        Destroy(player.GetComponent<TripleShot>());
        SpreadShot spread = player.AddComponent<SpreadShot>();
        spread.firepoint = player.GetComponent<PlayerController>().firePoint.transform;
        spread.bulletPrefab = player.GetComponent<PlayerController>().bulletPrefab;
        player.GetComponent<PlayerController>().attack = spread;
    }
}
