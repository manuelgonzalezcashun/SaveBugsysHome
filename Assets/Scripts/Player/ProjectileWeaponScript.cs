using System;
using System.Collections;
using UnityEngine;

public class ProjectileWeaponScript : MonoBehaviour
{
    [SerializeField] private Transform weaponProjectilePoint;
    [SerializeField] private GameObject projectile;

    private bool fireReady = true;
    private float weaponCooldown = 1f;

    void Update()
    {
        if (fireReady)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ObjectCollider.isProjectile = true;
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
