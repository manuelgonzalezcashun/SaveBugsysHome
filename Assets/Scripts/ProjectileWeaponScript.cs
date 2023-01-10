using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponScript : MonoBehaviour
{
    public Transform weaponProjectilePoint;
    public GameObject projectile;
    bool fireReady = true;
    float weaponCooldown = 1f;

    void Update()
    {
        if (fireReady)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Shoot();
                StartCoroutine(WeaponCooldown());
            }
        }
    }
    void Shoot()
    {
        Instantiate(projectile, weaponProjectilePoint.position, weaponProjectilePoint.rotation);
    }
    IEnumerator WeaponCooldown()
    {
        fireReady = false;
        yield return new WaitForSeconds(weaponCooldown);
        fireReady = true;
    }
}
