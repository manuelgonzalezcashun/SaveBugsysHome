using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileCoolDown : MonoBehaviour
{
    [SerializeField] private Image RaidialTimerUI;
    private float radialTime = 1f;
    private void CooldownTimer(float cooldown)
    {
        radialTime -= Time.deltaTime;
        RaidialTimerUI.enabled = true;
        RaidialTimerUI.fillAmount = radialTime;
        if (radialTime <= 0)
        {
            radialTime = cooldown;
            RaidialTimerUI.fillAmount = cooldown;
            RaidialTimerUI.enabled = false;
        }
    }
}
