using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    public void LoadLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Loading.sceneIndex = currentSceneIndex + 1;
        if (Loading.sceneIndex == 3)
        {
            SceneManager.LoadScene("Winner");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Loading.sceneIndex = 0;
        }
        else
        {
            LoadLoadingScene();
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
