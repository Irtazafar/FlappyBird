using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [HideInInspector]
    private GameManager gameManager;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5.0f;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ((Vector3.left * speed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameManager != null)
        {
            gameManager.ScoreUpdate();
        }

    }
}
