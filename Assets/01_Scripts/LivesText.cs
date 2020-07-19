using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LivesText : MonoBehaviour
{

    private const int MaxAmountOfCharacters = 2;
    private const char XCharacter = 'x';

    private LevelManager levelManager;
    [SerializeField] private TextMeshProUGUI LivesTextField;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        LivesTextField.text = XCharacter + levelManager.GetLives().ToString();
    }
  
}
