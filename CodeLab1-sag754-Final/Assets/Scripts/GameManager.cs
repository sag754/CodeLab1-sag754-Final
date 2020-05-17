using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int JumpToLevel = 2;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            Invoke("EndGame", 2f);
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene(JumpToLevel);
    }
}
