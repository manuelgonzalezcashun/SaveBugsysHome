using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartGame()
    {
        PausingScript.gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SaveBugsy'sHome");
    }
    public void QuitGame()
    {
        PausingScript.gameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
