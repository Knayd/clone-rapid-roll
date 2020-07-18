using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{

    private GameInfo gameInfo;
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        gameInfo = FindObjectOfType<GameInfo>();
    }

    void Update()
    {
        scoreText.text = gameInfo.GetScore().ToString();
    }
}
