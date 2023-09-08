using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Destroying clone insatnce");
            Destroy(gameObject);
        }

        DontDestroyOnLoad(instance);
    }
    public void LoadScene(Scenes scene)
    {
        if (!scene.isMenuScene)
        {
            SceneManager.LoadScene(scene.sceneName);
        }
        else
        {
            SceneManager.LoadScene(scene.sceneName, LoadSceneMode.Additive);
        }
    }
    public void UnloadMenuScene(Scenes scene)
    {
        SceneManager.UnloadSceneAsync(scene.sceneName);
    }
}
