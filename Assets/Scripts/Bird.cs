using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float velocity;
    public Rigidbody2D birdRigidBody;

    public GameManager gameManager;
    public bool isDead = false;

    private void Start()
    {
        velocity = 5.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Jump();
        }
    }

    private void Jump()
    {
        birdRigidBody.velocity = Vector2.up * velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        isDead = true;
        gameManager.GameOver();
    }

}
