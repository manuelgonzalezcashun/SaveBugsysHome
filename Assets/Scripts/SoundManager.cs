using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sound;
    public void PlaySound()
    {
        sound.Play();
    }
}
