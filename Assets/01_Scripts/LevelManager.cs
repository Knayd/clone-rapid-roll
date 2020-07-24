using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject levelScoreCanvas;

    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;

    private float countdownTimeBetweenScreens = 3f;

   
    //-------
    public void IncreaseScore() { score += 1; }
    public int GetScore() { return score; }


    public int GetLives() { return lives; }
    public void IncreaseLives() { lives += 1; }

    public void DecreaseLives() { lives -= 1; }

    //-------

    public void Start()
    {
         
    }

    public void Update()
    {
        GameIsOver();
    }

    // GameOver Screen ---------------------------------

    public void GameIsOver()
    {
        if (lives <= 0)
        {
            gameOverCanvas.SetActive(true);
            countdownTimeBetweenScreens -= Time.deltaTime;

            if (countdownTimeBetweenScreens <= 0)
            {
                gameOverCanvas.SetActive(false);
                levelScoreCanvas.SetActive(true);

            }
        }
    }
}


