using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] int score = 0;

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

    public void ResetGameInfo()
    {
        Destroy(gameObject);
    }
}
