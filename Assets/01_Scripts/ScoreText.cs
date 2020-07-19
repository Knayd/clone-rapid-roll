using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private const int MaxAmountOfDigits = 10;
    private const char LeftZeroChar = '0';

    private LevelManager levelManager;
    [SerializeField] private TextMeshProUGUI scoreTextField;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        scoreTextField.text = GetScoreWithLeadingZeros(levelManager.GetScore());
    }

    private string GetScoreWithLeadingZeros(int score)
    {
        return score.ToString(GetPlaceHolderWithZeros());
    }

    private string GetPlaceHolderWithZeros() { return new string(LeftZeroChar, MaxAmountOfDigits); }
}
