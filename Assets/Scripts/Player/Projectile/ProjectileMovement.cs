using System;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float projectileLifetime = 3f;
    public Rigidbody2D rb;
    private void OnEnable()
    {
        Enemy.onEnemyDeath += onHitEnemy;
    }
    private void OnDestroy()
    {
        Enemy.onEnemyDeath -= onHitEnemy;
    }
    void Update()
    {
        rb.velocity = Vector2.up * speed;
        Destroy(gameObject, projectileLifetime);
    }
    private void onHitEnemy()
    {
        Destroy(gameObject);
    }
}
