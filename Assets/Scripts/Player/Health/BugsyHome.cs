using System;
using UnityEngine;

public class BugsyHome : MonoBehaviour
{
    public static event Action<int> setCurrentHP;
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;
    private void OnEnable()
    {
        Enemy.onEnemyAttack += TakeDamage;
    }
    private void OnDisable()
    {
        Enemy.onEnemyAttack -= TakeDamage;
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        setCurrentHP?.Invoke(currentHealth);
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;        
        if (currentHealth == 0) PlayerDie();
    }
    private void PlayerDie()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over!");
    }
}
