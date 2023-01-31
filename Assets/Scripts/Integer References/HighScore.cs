using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreTag;
    public GameObject HighScorePanel;
    public IntegerVariableReference highScore;
    public IntegerVariableReference scorePoints;
    void Start()
    {
        highScoreTag.text = "High Score: " + highScore.Value;
    }
    public void Update()
    {
        if (scorePoints.Value > highScore.Value)
        {
            HighScorePanel.SetActive(true);
            highScore.Value = scorePoints.Value;
            highScoreTag.text = "High Score: " + highScore.Value;
        }
    }
}
