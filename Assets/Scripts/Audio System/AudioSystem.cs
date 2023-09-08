using System.Collections.Generic;
using UnityEngine;
public abstract class AudioSystem : MonoBehaviour
{
    public List<Sounds> sounds;
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
    public void Play(SoundID soundID)
    {
        foreach (Sounds sound in sounds)
        {
            if (sound.id == soundID)
            {
                sound.source.Play();
            }
        }
    }
}
