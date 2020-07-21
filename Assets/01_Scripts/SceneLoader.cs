using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject highScoreCanvas;
    [SerializeField] GameObject pauseMenuCanvas;
    

    public int getLocalSceneIndex;
    

    void Start()
    {
      
        getLocalSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    private void Update()
    {
        EnterPauseMenu();
    }



    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(getLocalSceneIndex - 1);

    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(getLocalSceneIndex);

    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(getLocalSceneIndex + 1);

    }

    // @ Main Menu ---------------------------------

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


    // @ Pause Menu ------------------------------------------

    public void EnterPauseMenu()
    {
        if (Input.GetKey(KeyCode.Escape) && pauseMenuCanvas.gameObject.activeInHierarchy == false)
        {

            pauseMenuCanvas.SetActive(true);
            
        }
        
    }

    public void QuitPauseMenu()
    {
        pauseMenuCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
