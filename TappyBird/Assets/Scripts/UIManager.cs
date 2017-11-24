using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startUI;
    public GameObject gameOverPanel;
    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Use this for initialization
    void Start()
    {
        startUI.SetActive(true);
    }
    public void GameStrat1()
    {
        startUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = ScoreManager.instance.score.ToString();

    }
    public void GameOver()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoaDMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
