using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

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
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == 3)
        {
            SceneManager.LoadScene("Winner");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
