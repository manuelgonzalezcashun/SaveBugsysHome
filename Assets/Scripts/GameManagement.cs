using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagement : MonoBehaviour
{
    [Header("Loading Screen")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingBar;
    [SerializeField] private TextMeshProUGUI LoadingTextPercent;
    
    IEnumerator LoadAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progress;
            LoadingTextPercent.text = progress * 100 + "%";
            yield return null;
        }
    }
    public void StartGame(int index)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsync(index));
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsync(0));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
