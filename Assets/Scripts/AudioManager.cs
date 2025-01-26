using UnityEngine.Audio;
using System;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    public SoundClass[] sounds;

    public static AudioManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        foreach (SoundClass s in sounds)
        {
            s.audioS = gameObject.AddComponent<AudioSource>();
            s.audioS.clip = s.clip;
            s.audioS.volume = s.volume;
            s.audioS.pitch = s.pitch;
            s.audioS.loop = s.loop;
            s.audioS.outputAudioMixerGroup = s.mixer;
        }
    }
    public void StopSound(string soundName)
    {
        SoundClass s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
            return;

        // Stop playback of the sound
        if (s.audioS.isPlaying)
        {
            s.audioS.Stop();
        }
    }

    public void PlaySound(string soundName, bool overlapping = true)
    {
        SoundClass s = Array.Find(sounds, sound => sound.name == soundName);
        if (s == null)
            return;

        if (overlapping)
        {
            s.audioS.PlayOneShot(s.clip);
        }
        else
        {
            if (!s.audioS.isPlaying)
                s.audioS.PlayOneShot(s.clip);
        }
    }
}


