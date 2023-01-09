using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePoints : MonoBehaviour
{
    public TextMeshProUGUI scoreTag; 
    public IntegerVariableReference scorePoints;

    void Start()
    {
        scorePoints.Value = 0;
        scoreTag.text = "Score: " + scorePoints.Value;
    }
    public void Update()
    {
        scoreTag.text = "Score: " + scorePoints.Value;
    }
}
