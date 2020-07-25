using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] PlayerSpawner playerSpawner;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject levelScoreCanvas;
    [SerializeField] GameObject gameStartCanvas;

    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;

    private float countdownTimeBetweenScreens = 3f;

    //-------
    public void IncreaseScore() { score += 1; }
    public int GetScore() { return score; }


    public int GetLives() { return lives; }
    public void IncreaseLives() { lives += 1; }

    public void DecreaseLives()
    {
        lives -= 1;
        StartCoroutine(GameIsOver());
    }

    //-------

    IEnumerator Start()
    {
        //Wait for player to spawn, then disable game start screen.
        yield return playerSpawner.SpawnObject();
        gameStartCanvas.SetActive(false);
    }

    // GameOver Screen ---------------------------------

    private IEnumerator GameIsOver()
    {
        if (lives <= 0)
        {
            gameOverCanvas.SetActive(true);
            yield return new WaitForSeconds(countdownTimeBetweenScreens);
            gameOverCanvas.SetActive(false);
            levelScoreCanvas.SetActive(true);
        }
        else
        {
            yield return playerSpawner.SpawnObject();
        }
    }
}


