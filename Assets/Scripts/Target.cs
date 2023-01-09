using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    private GameObject target;
    public float speed;
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
           target = GameObject.Find("PlayerHouse"); 
        }
        else if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            target = GameObject.Find("DestroyObject1");
        }
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
