using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private const int MaxAmountOfDigits = 10;
    private const char LeftZeroChar = '0';

    private GameInfo gameInfo;
    [SerializeField] private TextMeshProUGUI scoreTextField;

    void Start()
    {
        gameInfo = FindObjectOfType<GameInfo>();
    }

    void Update()
    {
        scoreTextField.text = GetScoreWithZeros(gameInfo.GetScore());
    }

    private string GetScoreWithZeros(int score)
    {
        var scoreString = score.ToString();
        var scoreLength = scoreString.Length;

        if (scoreLength < MaxAmountOfDigits)
        {
            var scoreStartIndex = MaxAmountOfDigits - scoreLength;

            var formattedScore = GetPlaceHolderWithZeros();
            formattedScore = formattedScore.Remove(scoreStartIndex, scoreLength).Insert(scoreStartIndex, scoreString);
            return formattedScore;
        }
        else
        {
            return scoreString;
        }
    }

    private string GetPlaceHolderWithZeros() { return new string(LeftZeroChar, MaxAmountOfDigits); }
}
