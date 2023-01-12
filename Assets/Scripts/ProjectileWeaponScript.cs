using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileWeaponScript : MonoBehaviour
{
    public Image RaidialTimerUI;
    private float radialTime = 1f;
    public Transform weaponProjectilePoint;
    public GameObject projectile;
    bool fireReady = true;
    float weaponCooldown = 1f;

    void Start()
    {

    }

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
        else
        {
            radialTime -= Time.deltaTime;
            RaidialTimerUI.enabled = true;
            RaidialTimerUI.fillAmount = radialTime;
            if (radialTime <= 0)
            {
                radialTime = weaponCooldown;
                RaidialTimerUI.fillAmount = weaponCooldown;
                RaidialTimerUI.enabled = false;
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
