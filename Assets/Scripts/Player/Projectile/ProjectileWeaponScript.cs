using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileWeaponScript : MonoBehaviour
{
    public static event Action <float, bool> onFireEvent;
    [SerializeField] private Transform weaponProjectilePoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float weaponCooldown = 1f;
    [SerializeField] private PlayerInput playerInput;
    private InputAction fireAction;
    private bool fireReady = true;
    

    void Awake()
    {
        fireAction = playerInput.actions["Fire"];
    }
    void OnEnable()
    {
        fireAction.performed += ctx => Shoot();
    }
    void OnDisable()
    {
        fireAction.performed -= ctx => Shoot();
    }
    void Shoot()
    {
        if (fireReady)
        {
            Instantiate(projectile, weaponProjectilePoint.position, weaponProjectilePoint.rotation);
            StartCoroutine(WeaponCooldown());
        }
    }
    private void Update()
    {
       onFireEvent?.Invoke(weaponCooldown, fireReady);
    }
    IEnumerator WeaponCooldown()
    {
        fireReady = false;
        yield return new WaitForSeconds(weaponCooldown);
        fireReady = true;
    }
}
