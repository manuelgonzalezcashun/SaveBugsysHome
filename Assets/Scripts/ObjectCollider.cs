using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ObjectCollider : MonoBehaviour
{
    public GameObject obj;
    public UnityEvent objectCollision;
    public IntegerVariableReference scorePoints;
    public IntegerVariableReference healthPoints;
    private SoundManager sm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerHouse")
        {
            healthPoints.Value -= 1;
            objectCollision.Invoke();
        }
        if (other.tag == "Projectile")
        {
            scorePoints.Value += 1;
            objectCollision.Invoke();
        }
        if (other.tag == "DestroyProjectile")
        {
            objectCollision.Invoke();
        }
        if (other.tag == "Enemy")
        {
            objectCollision.Invoke();
        }
    }
    public void DestroyObject()
    {
        Destroy(obj);
    }
}
