using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Text highScoreText;
    private GameObject startUI;
    public bool gameOver;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        
        highScoreText = GameObject.Find("Score Text").GetComponent<Text>();
        gameOver = true;
    }
    public void GameStart()
    {
        UIManager.instance.GameStrat1();
        GameObject.Find("Pipe Spawner").GetComponent<PipeSpawner>().StartSpawningPipes();

    }
    public void GameOver()
    {
        gameOver = false;
        GameObject.Find("Pipe Spawner").GetComponent<PipeSpawner>().StopSpawningPipes();
        ScoreManager.instance.StopScore();
        UIManager.instance.GameOver();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
