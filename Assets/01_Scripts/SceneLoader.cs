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
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] GameObject LevelScoreCanvas;
    private LevelManager levelManager;

    private float timeCountdownBetweenScreens = 3f;

    public int getLocalSceneIndex;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        getLocalSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    private void Update()
    {
        EnterPauseMenu();
        GameOverScreen();
    }



    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(getLocalSceneIndex - 1);

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


    // @ GameOver Screen ------------------------------------------

    public void GameOverScreen()
    {
        var playerLives = levelManager.GetLives();
        if (playerLives <= 0)
        {

            GameOverCanvas.SetActive(true);
            timeCountdownBetweenScreens -= Time.deltaTime;
            if (timeCountdownBetweenScreens <= 0)
            {
                GameOverCanvas.SetActive(false);
                LevelScoreCanvas.SetActive(true);
                    
            }

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
