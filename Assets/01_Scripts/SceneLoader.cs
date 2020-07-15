using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject highScoreCanvas;

    

    public int getLocalSceneIndex;

    void Start()
    {
        getLocalSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(getLocalSceneIndex + 1);

    }

    public void ActivateLevelSelect()
    {
        
        mainMenuCanvas.SetActive(false);
        levelCanvas.SetActive(true);
    }

    public void ActivateHightscores()
    {
        mainMenuCanvas.SetActive(false);
        highScoreCanvas.SetActive(true);

    }

    public void BackButton()
    {
        if (mainMenuCanvas.gameObject.activeInHierarchy == false)
        {

            levelCanvas.SetActive(false);
            highScoreCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
