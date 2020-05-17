using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int JumpToLevel = 2;
    public static int points = 0;

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
        if(points == 1)
        {
            
            Invoke("Complete", 1f);
        }

        if(player == null)
        {
            Invoke("EndGame", 2f);
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene(JumpToLevel);
    }

    void Complete()
    {
        SceneManager.LoadScene(3);
    }
}
