using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    [SerializeField] private int flowersToSpawn;
    [SerializeField] private GameObject flower;
    [SerializeField] private Transform groundToSpawn;
    void Start()
    {
        for (int i = 0; i < flowersToSpawn; i++)
        {
            Vector2 spawnPosition = GetRandomSpawnPos(groundToSpawn);
            Instantiate(flower, spawnPosition, Quaternion.identity, groundToSpawn);
        }
    }
    private Vector2 GetRandomSpawnPos(Transform parent, float offset = 0.5f)
    {
        Bounds groundBounds = parent.GetComponent<Collider2D>().bounds;

        Vector2 minBounds = new Vector2(groundBounds.min.x + offset, groundBounds.min.y + offset);
        Vector2 maxBounds = new Vector2(groundBounds.max.x - offset, groundBounds.max.y - offset);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);

        return new Vector2(randomX, randomY);
    }
}
