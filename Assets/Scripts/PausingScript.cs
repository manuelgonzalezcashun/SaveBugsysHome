using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    private AudioSource playSnd;
    public GameObject player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (gameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        player.SetActive(true);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        player.SetActive(false);
    }
}