using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;
    

   public SceneLoader sceneLoader;
    

    public void IncreaseScore() { score += 1; }
    public int GetScore() { return score; }


    public int GetLives() { return lives; }
    public void IncreaseLives() { lives += 1; }

    public void DecreaseLives() { lives -= 1; }

    public void GameIsOver() {
       if(lives <= 0) {

            sceneLoader.gameIsOver = true;
            Debug.Log("game is over");
        }
        
            }

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

}
