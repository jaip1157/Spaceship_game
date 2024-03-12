using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
     private float waitTime = 2.0f;
    private float timer = 0.0f;
    private float visualTime = 0.0f;

    [ContextMenu("Increase Score")]
    public void addScore(int scoretoadd)
    {
        playerScore = playerScore + scoretoadd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            visualTime = timer;
            addScore(1);
            timer = timer - waitTime;
        }
    }

}