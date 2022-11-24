using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    Button continueButton;

    void Start()
    {
        continueButton = GetComponent<Button>();
        continueButton.interactable = SaveSystem.SaveFileExists();
    }

    void Update()
    {
        
    }
}

