using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LivesText : MonoBehaviour
{

    private const int MaxAmountOfCharacters = 2;
    private const char XCharacter = 'x';

    private LevelManager LevelManager;
    [SerializeField] private TextMeshProUGUI LivesTextField;

    void Start()
    {
        LevelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        LivesTextField.text = XCharacter + LevelManager.GetLives().ToString();
    }
  
}
