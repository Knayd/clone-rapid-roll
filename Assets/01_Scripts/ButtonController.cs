using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    void Update()
    {
        
    }
}

