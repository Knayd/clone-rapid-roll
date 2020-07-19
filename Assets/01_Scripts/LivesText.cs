using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LivesText : MonoBehaviour
{
    private GameInfo gameInfo;
    [SerializeField] private TextMeshProUGUI LivesTextField;

    void Start()
    {
        gameInfo = FindObjectOfType<GameInfo>();
    }

    void Update()
    {
        LivesTextField.text = GetLivesAmount(gameInfo.GetLives());
    }

    private string GetLivesAmount(int lives)
    {
        return lives.ToString();
    }
}
