using UnityEngine;
using UnityEngine.UI;

public class ProjectileCooldownUI : MonoBehaviour
{
    [SerializeField] private Image radialTimerUI;
    
    private float radialTime;

    private void OnEnable()
    {
        ProjectileWeaponScript.onFireEvent += ShowTimer;
    }

    private void OnDisable()
    {
        ProjectileWeaponScript.onFireEvent -= ShowTimer;
    }

    private void ShowTimer(float cooldown, bool canFire )
    {
         if (!canFire && radialTime > 0)
        {
            radialTimerUI.enabled = true;
            radialTime -= Time.deltaTime;
            radialTimerUI.fillAmount = radialTime / cooldown;
        }
        else
        {
            radialTimerUI.enabled = false;
            radialTime = cooldown;
            radialTimerUI.fillAmount = cooldown;
        }
    }
}
