using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelForwarder : MonoBehaviour
{

    public int JumpToLevel = 0;

    public static LevelForwarder instance;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameInstance.gameComplete = false;
        GameManager.gameInstance.gameOver = false;
        PlayerController.playerInstance.health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene(JumpToLevel);
        }
    }
}