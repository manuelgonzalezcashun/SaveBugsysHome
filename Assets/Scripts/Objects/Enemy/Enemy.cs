using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action <int> onEnemyAttack;
    public static event Action onEnemyDeath;
    [SerializeField] private float speed;
    [SerializeField] private int enemyDamage = 1;
    private GameObject target;

    private void Awake()
    {
        target = FindObjectOfType<BugsyHome>().gameObject;
        EnemyRotate();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void EnemyRotate()
    {
        if (gameObject.transform.position.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Home"))
        {
            onEnemyAttack?.Invoke(enemyDamage);
            
        }
        if (collider.gameObject.CompareTag("Projectile"))
        {
            onEnemyDeath?.Invoke();
        }
        
        Destroy(gameObject);
    }
}
