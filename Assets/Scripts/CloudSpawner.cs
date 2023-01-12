using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudSpawner : MonoBehaviour
{
    public float spawnInterval = 3.5f;
    public GameObject clouds;
    public GameObject floor;
    public GameObject spawner;

    void Start()
    {
        StartCoroutine(spawnInLeftMenu(spawnInterval, clouds));
        StartCoroutine(spawnInBottomMenu(floor));
        Instantiate(floor, new Vector3(0, -4, (float)0.5), Quaternion.identity, spawner.transform);
        Instantiate(floor, new Vector3(3, -4, (float)0.5), Quaternion.identity, spawner.transform);
    }
    public IEnumerator spawnInLeftMenu(float interval, GameObject obj)
    {
        yield return new WaitForSeconds(interval);
        GameObject newObj = Instantiate(obj, new Vector3(10, Random.Range(3, 5), (float)0.5), Quaternion.identity, spawner.transform);
        StartCoroutine(spawnInLeftMenu(interval, obj));
    }
    public IEnumerator spawnInBottomMenu(GameObject obj)
    {
        yield return new WaitForSeconds(2.5f);
        GameObject newObj = Instantiate(obj, new Vector3(10, -4, (float)0.5), Quaternion.identity, spawner.transform);
        StartCoroutine(spawnInBottomMenu(obj));
    }
}
