using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthTag;
    public IntegerVariableReference healthPoints, maxHealthPoints;
    public GameObject DeathScreen;
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        healthPoints.Value = maxHealthPoints.Value;
    }
    public void Update()
    {
        float fillValue = healthPoints.Value / maxHealthPoints.Value;
        slider.value = fillValue;
        GameOver();
    }

    void GameOver()
    {
        if (healthPoints.Value == 0)
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (healthPoints.Value > 0 && PausingScript.gameIsPaused == false)
        {
            Time.timeScale = 1f;
        }
    }
}
