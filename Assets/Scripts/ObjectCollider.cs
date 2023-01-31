using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ObjectCollider : MonoBehaviour
{
    public GameObject obj;
    public UnityEvent objectCollision;
    public IntegerVariableReference scorePoints;
    public IntegerVariableReference highScorePoints;
    public IntegerVariableReference healthPoints;
    private SoundManager sm;
    public static bool isProjectile = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerHouse")
        {
            healthPoints.Value -= 1;
            objectCollision.Invoke();
        }
        if (other.tag == "Projectile")
        {
            GameObject spl = GameObject.Find("SPLAT");
            AudioSource splat = spl.GetComponent<AudioSource>();
            splat.Play();
            scorePoints.Value += 1;
            isProjectile = false;
            if (highScorePoints.Value < scorePoints.Value)
            {
                highScorePoints.Value = scorePoints.Value;
            }
            objectCollision.Invoke();
        }
        if (other.tag == "DestroyProjectile")
        {
            objectCollision.Invoke();
        }
        if (other.tag == "Enemy" && isProjectile == true)
        {
            objectCollision.Invoke();
        }
    }
    public void DestroyObject()
    {
        Destroy(obj);
    }
}
