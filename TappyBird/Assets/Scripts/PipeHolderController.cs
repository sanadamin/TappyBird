using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolderController : MonoBehaviour
{
    [SerializeField]
    private float speed, verticalSpeed;

    private Rigidbody2D rigidBody;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        MovePipes();
        InvokeRepeating("SwtichVertical", 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SwtichVertical()
    {
        verticalSpeed = -verticalSpeed;
        rigidBody.velocity = new Vector2(-speed, verticalSpeed);
    }
    void MovePipes()
    {
        rigidBody.velocity = new Vector2(-speed, verticalSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Shredder")
        {
            Destroy(gameObject);
        }
    }
}
