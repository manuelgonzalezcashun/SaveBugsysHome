using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthTag;
    [SerializeField] private Slider healthBar;

    void Awake()
    {
        BugsyHome.setCurrentHP += UpdateHealthUI;
    }
    private void OnDestroy()
    {
        BugsyHome.setCurrentHP -= UpdateHealthUI;
    }
    private void UpdateHealthUI(int hp)
    {
        healthTag.text = $"Health: {hp}";
        healthBar.value = hp;
    }
}