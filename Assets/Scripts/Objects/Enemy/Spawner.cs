using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 2.5f;
    [SerializeField] GameObject enemy;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemy));
    }
    public IEnumerator spawnEnemy(float interval, GameObject obj)
    {
        yield return new WaitForSeconds(interval);
        Instantiate(obj, new Vector3(Random.Range(-10, 11), 5, -1), Quaternion.identity, gameObject.transform);
        StartCoroutine(spawnEnemy(interval, obj));
    }
}
