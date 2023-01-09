using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponScript : MonoBehaviour
{
    public Transform weaponProjectilePoint;
    public GameObject projectile;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(projectile, weaponProjectilePoint.position, weaponProjectilePoint.rotation);
    }
}
