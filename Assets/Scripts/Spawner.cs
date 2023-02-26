using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnInterval = 3.5f;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject spawner;
    private PausingScript pause;

    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemy));
    }
    public IEnumerator spawnEnemy(float interval, GameObject obj)
    {
        yield return new WaitForSeconds(interval);
        GameObject newObj = Instantiate(obj, new Vector3(Random.Range(-10, 11), 5, -1), Quaternion.identity, spawner.transform);
        StartCoroutine(spawnEnemy(interval, obj));
    }
}
