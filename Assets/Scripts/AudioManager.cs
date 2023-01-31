using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Toggle muteToggle;

    void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    { 
        Play("Theme");
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
    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        if (s == null)
        {
            Debug.LogError("Sound " + s + " was not found!");
            return;
        }
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
            Save();
        }
        else
        {
            AudioListener.volume = 1;
            volumeSlider.value = 1;
            Save();
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
        PlayerPrefs.SetInt("ToggleSelected", (int)volumeSlider.value); 
    }
}
