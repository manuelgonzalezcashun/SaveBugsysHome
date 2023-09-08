using UnityEngine;
using TMPro;

public class ScorePoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTag; 
    [SerializeField] private TextMeshProUGUI highScoreTag;
    private int score;
    private int highScore;
    private void OnEnable()
    {
        Enemy.onEnemyDeath += UpdateScore;
    }
    private void OnDisable()
    {
        Enemy.onEnemyDeath -= UpdateScore;
    }
    private void Update()
    {
        scoreTag.text = $"Score: {score}";
    }
    private void UpdateScore()
    {
        score += 1;
    }
}
