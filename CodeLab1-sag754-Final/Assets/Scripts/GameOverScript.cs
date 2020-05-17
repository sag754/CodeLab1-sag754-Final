﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public int JumpToLevel = 0;

    public static LevelForwarder instance;


    void Start()
    {
        Invoke("ReloadGame", 8f);
    }

    void ReloadGame()
    {
        SceneManager.LoadScene(JumpToLevel);
    }
}