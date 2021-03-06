﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteScript : MonoBehaviour
{
    public int JumpToLevel = 3;

    public static LevelForwarder instance;


    void Start()
    {
        Destroy(GameObject.FindWithTag("Enemy"));
        Destroy(GameObject.FindWithTag("Player"));
        PlayerController.points = 0;
        Invoke("ReloadGame", 7f);
    }

    void ReloadGame()
    { 
        SceneManager.LoadScene(JumpToLevel);
    }
}
