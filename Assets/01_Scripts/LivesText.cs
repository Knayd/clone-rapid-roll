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
        LivesTextField.text = XCharacter + gameInfo.GetLives().ToString();
    }

  

  
}
