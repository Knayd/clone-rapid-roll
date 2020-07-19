using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LivesText : MonoBehaviour
{

    private const int MaxAmountOfCharacters = 2;
    private const char XCharacter = 'x';

    private GameInfo gameInfo;
    [SerializeField] private TextMeshProUGUI LivesTextField;

    void Start()
    {
        gameInfo = FindObjectOfType<GameInfo>();
    }

    void Update()
    {
        LivesTextField.text = XCharacter + GetLivesAmount(gameInfo.GetLives());
    }

    private string GetLivesAmount(int lives)
    {
        return lives.ToString(); 
    }

    /**
    private string GetPlaceholderCharacter()
    {
        return new string(XCharacter, MaxAmountOfCharacters);
    }
    */
}
