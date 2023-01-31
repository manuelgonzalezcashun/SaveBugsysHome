using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public LeaderboardController leaderboard;
    public GameObject DeathScreen;
    public TextMeshProUGUI healthTag;
    public IntegerVariableReference healthPoints, maxHealthPoints;
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
    }
    public void FixedUpdate()
    {
        GameOver();
    }
    void GameOver()
    {
        if (healthPoints.Value <= 0)
        {
            healthPoints.Value = 0;
            leaderboard.SubmitScore();
            Debug.Log("Submitting Scores");
            DeathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}