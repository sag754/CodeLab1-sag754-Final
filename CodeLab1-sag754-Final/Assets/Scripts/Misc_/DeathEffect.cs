using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    public float destructTimer = .1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", destructTimer);
    }

    // Update is called once per frame
    void DestroySelf()
    {
        Destroy(gameObject);
    }


}
