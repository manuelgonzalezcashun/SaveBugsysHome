using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreTag;
    public GameObject HighScorePanel;
    public IntegerVariable highScore;
    public IntegerVariableReference scorePoints;
    public void Update()
    {
        if (scorePoints.Value > highScore.value)
        {
            HighScorePanel.SetActive(true);
            highScore.value += 1;
            highScoreTag.text = "High Score: " + highScore.value;
        }
    }
}
