using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    
    public int getLocalSceneIndex;

    void Start()
    {
        getLocalSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(getLocalSceneIndex + 1);
    
    }

    public void LoadLevelSelect()
    {
       

    }

    public void LoadHightscores()
    {
        

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
