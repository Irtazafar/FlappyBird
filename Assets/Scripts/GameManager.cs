using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverImage;
    public GameObject startButton;
    public Bird player;

    public Text totalGameScore;
    public Text gameScore;
    public Text gameOverCountDown;
    public float countTimer = 5;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOverCountDown.gameObject.SetActive(false);
        GameOverImage.gameObject.SetActive(false);
        gameScore.gameObject.SetActive(false);
        totalGameScore.gameObject.SetActive(false);
        Time.timeScale = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isDead)
        {
            gameOverCountDown.gameObject.SetActive(true);
            GameOverImage.gameObject.SetActive(true);
            countTimer -= Time.unscaledDeltaTime;
        }

        gameOverCountDown.text = "Restarting in " + (countTimer).ToString("0");
        totalGameScore.text = "Score: " + (score).ToString("0");

        if(countTimer <0)
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        gameScore.gameObject.SetActive(true);
        score = 0;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameScore.gameObject.SetActive(false);
        totalGameScore.gameObject.SetActive(true);
    }


    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ScoreUpdate()
    {
        score++;
        gameScore.text = score.ToString();
    }
}
