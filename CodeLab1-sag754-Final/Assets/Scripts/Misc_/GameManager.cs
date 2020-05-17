using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int JumpToLevel = 2;

    public bool gameOver = false;
    public bool gameComplete = false;

    public AudioSource complete;

    public GameObject player;
    public static GameManager gameInstance;


    void Start()
    {
        //set up the singleton
        if (gameInstance == null)
        { //if instance isn't set
            gameInstance = this; //set it to this instance
            DontDestroyOnLoad(gameObject); //Don't destory this gameObject
        }
        else
        { //otherwise, if we have a singleton already
            Destroy(gameObject); //Destroy this instance
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.points == 50 && gameComplete == false)
        {
            gameComplete = true;
            Invoke("Complete", 1f);
        }

        if(PlayerController.playerInstance.health <= 0 && gameOver == false)
        {
            gameOver = true;
            Invoke("GameOver", 2f);
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(JumpToLevel);
    }

    void Complete()
    {
        SceneManager.LoadScene(3);
    }
}
