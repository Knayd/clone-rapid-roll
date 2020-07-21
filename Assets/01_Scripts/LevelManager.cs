using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] GameObject LevelScoreCanvas;

    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;

    private float countdownTimeBetweenScreens = 3f;

    private SceneLoader sceneLoader;
   
    //-------
    public void IncreaseScore() { score += 1; }
    public int GetScore() { return score; }


    public int GetLives() { return lives; }
    public void IncreaseLives() { lives += 1; }

    public void DecreaseLives() { lives -= 1; }

    //-------

    public void Start()
    {
         if (sceneLoader == null)
        {
            sceneLoader = FindObjectOfType<SceneLoader>();
        }
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
            GameOverCanvas.SetActive(true);
            countdownTimeBetweenScreens -= Time.deltaTime;

            if (countdownTimeBetweenScreens <= 0)
            {
                GameOverCanvas.SetActive(false);
                LevelScoreCanvas.SetActive(true);

            }
        }
    }
}


