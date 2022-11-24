using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject levelCanvas;
    [SerializeField] GameObject highScoreCanvas;
    [SerializeField] GameObject pauseMenuCanvas;

    

    public int getLocalSceneIndex;
    private bool isPaused;

    private void Awake()
    {
       
    }
    void Start()
    {
        
        getLocalSceneIndex = SceneManager.GetActiveScene().buildIndex;

       
            if (GameStatusTracker.Continue)
            {
                SaveSystem.Load();
            } 
        

        

    }


    private void Update()
    {
      

        EnterPauseMenu();
        if (isPaused == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
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
    
    public void Continue()
    {
        LoadNextScene();
        
        //SaveSystem.Load();
        GameStatusTracker.Continue = true;
    }

    public void NewGame()
    {
        GameStatusTracker.Continue = false;
        LoadNextScene();
        //SaveSystem.DeleteSaveFile();
        
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

    public void BackMainMenu()
    {
        SaveSystem.Save();

    }

    public void EnterPauseMenu()
    {
        if (Input.GetKey(KeyCode.Escape) && pauseMenuCanvas.gameObject.activeInHierarchy == false)
        {

            pauseMenuCanvas.SetActive(true);
            isPaused = true;
            
            
        }
       
        
    }

    public void QuitPauseMenu()
    {
        pauseMenuCanvas.SetActive(false);
        isPaused = false;
       
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
