using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float interval = 15f;
    public GameObject[] powerUp;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPowerUp", interval, interval);
    }

    void SpawnPowerUp()
    {
        int randomPowerUp = Random.Range(0, powerUp.Length - 1);
        GameObject power = Instantiate<GameObject>(powerUp[randomPowerUp]);
    }
}
