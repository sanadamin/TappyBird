using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public AudioClip lostSound;
    public AudioClip flapSound;
    public float rotationAmount;

    [SerializeField]
    private float upForce;
    private Rigidbody2D rigidBody;
    private bool isStarted = false;
    private bool gameOver;
    private Animator animator;
    private Animator playerAnimator;
    private AudioSource[] audioSources;
    private AudioSource audioSource;
    private AudioSource audioSourceflap;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 1.5f;
        gameOver = false;
        animator = GameObject.Find("Game Over Panel").GetComponent<Animator>();
        playerAnimator = GetComponent<Animator>();
        audioSources = GameObject.FindObjectsOfType<AudioSource>();
        foreach (AudioSource thisAudioSource in audioSources)
        {
            if (thisAudioSource.priority == 129)
            {
                audioSource = thisAudioSource;
            }
            else if (thisAudioSource.priority == 130)
            {
                audioSourceflap = thisAudioSource;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted & Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            rigidBody.isKinematic = false;
            GameManager.instance.GameStart();
        }
        else if (isStarted  && !gameOver)
        {
            transform.Rotate(0f, 0f, rotationAmount);
            if (Input.GetMouseButtonDown(0)) { 
            if (!audioSourceflap.isPlaying)
            {
                audioSourceflap.clip = flapSound;
                audioSourceflap.Play();
                
            }
            rigidBody.velocity = Vector2.zero;
            rigidBody.velocity = new Vector3(0, upForce, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.clip = lostSound;
        audioSource.Play();
        gameOver = true;
        animator.SetTrigger("GameOverTrigger");
        GameManager.instance.GameOver();
        playerAnimator.SetTrigger("GameOverTrigger");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pipe" && !gameOver)
        {
            audioSource.clip = lostSound;
            audioSource.Play();
            gameOver = true;
            animator.SetTrigger("GameOverTrigger");
            GameManager.instance.GameOver();
            playerAnimator.SetTrigger("GameOverTrigger");

        }
        if (collision.gameObject.tag == "ScoreChecker" && !gameOver)
        {
            ScoreManager.instance.IncrementScore();
        }
    }


}
