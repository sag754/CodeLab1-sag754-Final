using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public int JumpToLevel = 0;

    public static LevelForwarder instance;


    void Start()
    {
        PlayerController.points = 0;
        Invoke("ReloadGame", 10f);
    }

    void ReloadGame()
    {
        Destroy(GameObject.FindWithTag("Enemy"));
        SceneManager.LoadScene(JumpToLevel);
    }
}
