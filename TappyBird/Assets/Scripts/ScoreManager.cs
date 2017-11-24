using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;

    public Text scoreText;
    public AudioClip passSound;


    private AudioSource[] audioSources;
    private AudioSource audioSource;
    public int score;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void IncrementScore()
    {
        score += 1;
        audioSource.clip = passSound;
        audioSource.Play();
    }
	// Use this for initialization
	void Start () {
        score = 0;
        audioSources = GameObject.FindObjectsOfType<AudioSource>();
        foreach(AudioSource thisAudioSource in audioSources)
        {
            if(thisAudioSource.priority == 129)
            {
                audioSource = thisAudioSource;
            }
        }

        PlayerPrefs.SetInt("score", score);
	}
	
    public void StopScore()
    {
        PlayerPrefs.SetInt("score", score);
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
