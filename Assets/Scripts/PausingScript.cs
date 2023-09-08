using UnityEngine;
using UnityEngine.InputSystem;

public class PausingScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private InputAction pauseInput;
    public static bool gameIsPaused = false;
    
    void OnEnable()
    {
        pauseInput.Enable();
        pauseInput.performed += ctx => TogglePauseStates();
    }
    void OnDisable()
    {
        pauseInput.Disable();
        pauseInput.performed -= ctx => TogglePauseStates();
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void TogglePauseStates()
    {
        if (!gameIsPaused)
        {
            Pause();
        }
        else 
        {
            Resume();
        }
    }
}
