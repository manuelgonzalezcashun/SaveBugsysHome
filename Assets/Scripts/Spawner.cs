using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public float spawnInterval = 3.5f;
    public GameObject enemyLeft;
    public GameObject enemyRight;
    public GameObject spawner;
    private PausingScript pause;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(spawnEnemyLeft(spawnInterval, enemyLeft));
            StartCoroutine(spawnEnemyRight(spawnInterval, enemyRight));
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(spawnInLeftMenu(spawnInterval, enemyRight));
            StartCoroutine(spawnInRightMenu(spawnInterval, enemyRight));
        }
    }
    public IEnumerator spawnEnemyLeft(float interval, GameObject obj)
    {
        yield return new WaitForSeconds(interval);
        GameObject newObj = Instantiate(obj, new Vector3(Random.Range(1, 10), 5, -1), Quaternion.identity, spawner.transform);
        StartCoroutine(spawnEnemyLeft(interval, obj));
    }
    public IEnumerator spawnEnemyRight(float interval, GameObject obj)
    {
        yield return new WaitForSeconds(interval);
        GameObject newObj = Instantiate(obj, new Vector3(Random.Range(-10, 0), 5, -1), Quaternion.identity, spawner.transform);
        StartCoroutine(spawnEnemyRight(interval, obj));
    }
    public IEnumerator spawnInLeftMenu(float interval, GameObject obj)
    {
        yield return new WaitForSeconds(interval);
        GameObject newObj = Instantiate(obj, new Vector3(10, Random.Range(-10, 10), (float)0.5), Quaternion.identity, spawner.transform);
        StartCoroutine(spawnInLeftMenu(interval, obj));
    }
    public IEnumerator spawnInRightMenu(float interval, GameObject obj)
    {
        yield return new WaitForSeconds(interval);
        GameObject newObj = Instantiate(obj, new Vector3(-10, Random.Range(-10, 10), (float)0.5), Quaternion.identity, spawner.transform);
        StartCoroutine(spawnInRightMenu(interval, obj));
    }
}
