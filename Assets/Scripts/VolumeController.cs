using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle muteToggle;

    private int isToggled = 1;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = volumeSlider.value;
        if (PlayerPrefs.GetInt("ToggleSelected") == 0)
        {
            muteToggle.isOn = true;
        }
        else if (PlayerPrefs.GetInt("ToggleSelected") == 1)
        {
            muteToggle.isOn = false;
        }
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetInt("ToggleSelected", isToggled);
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
    public void Mute()
    {
        if (muteToggle.isOn)
        {
            AudioListener.volume = 0;
            volumeSlider.value = 0;
            isToggled = 0;
            Save();
        }
        else
        {
            AudioListener.volume = 1;
            volumeSlider.value = 1;
            isToggled = 1;
            Save();
        }
    }
}
