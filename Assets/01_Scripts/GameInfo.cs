using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] private int score = 0;
    [SerializeField] private int lives = 3;
    void Awake()
    {
        if (FindObjectsOfType<GameInfo>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void IncreaseScore() { score += 1; }
    public int GetScore() { return score; }


    public int GetLives() { return lives; }
    public void IncreaseLives() { lives += 1; }


    public void ResetGameInfo()
    {
        Destroy(gameObject);
    }
}
