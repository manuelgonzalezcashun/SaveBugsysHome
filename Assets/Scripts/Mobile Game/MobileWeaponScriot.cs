using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileWeaponScriot : MonoBehaviour
{
   public Image RaidialTimerUI;
    private float radialTime = 1f;
    public Transform weaponProjectilePoint;
    public GameObject projectile;
    bool fireReady = false;
    bool shotFired = false;
    float weaponCooldown = 1f;

    void Update()
    {
        if (fireReady)
        {
                ObjectCollider.isProjectile = true;
                Shoot();
                shotFired = true;
                StartCoroutine(WeaponCooldown());
        }
        if (shotFired)
        {
            radialTime -= Time.deltaTime;
            RaidialTimerUI.enabled = true;
            RaidialTimerUI.fillAmount = radialTime;
            if (radialTime <= 0)
            {
                radialTime = weaponCooldown;
                RaidialTimerUI.fillAmount = weaponCooldown;
                RaidialTimerUI.enabled = false;
                shotFired = false;
            }
        }
    }
    public void Shoot()
    {
        Instantiate(projectile, weaponProjectilePoint.position, weaponProjectilePoint.rotation);
    }
    IEnumerator WeaponCooldown()
    {
        fireReady = false;
        yield return new WaitForSeconds(weaponCooldown);
    }
    public void setFireReady()
    {
        fireReady = true;
    }
}
