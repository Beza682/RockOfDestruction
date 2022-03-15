using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [Header("Toggles")]
    public Toggle music;
    public Toggle effects;
    public Toggle vibration;

    [Header("AudioSources")]

    public AudioSource backgroundSource;
    public AudioSource effectsSource;

    [Header("AudioClips")]
    public AudioClip[] background;
    public AudioClip button;

    void Start()
    {
        BackgroundSound();
    }

    void Update()
    {
        
    }
    public void BackgroundSound()
    {
        if (!music.isOn)
        {
            backgroundSource.clip = background[0];
            backgroundSource.Play();
        }
    }
    public void GameSound()
    {
        if (!music.isOn)
        {
            backgroundSource.clip = background[1];
            backgroundSource.Play();
        }
    }
    public void ClickSound()
    {
        if (!effects.isOn)
        {
            effectsSource.clip = button;
            effectsSource.Play();
        }
    }
    public void MuteMusic()
    {
        if (music.isOn)
        {
            backgroundSource.mute = true;
        }
        else
        {
            backgroundSource.mute = false;
        }
    }
    public void MuteEffects()
    {
        effectsSource.mute = effects.isOn;
        //if (effects.isOn)
        //{
        //    effectsSource.mute = true;
        //}
        //else
        //{
        //    effectsSource.mute = false;
        //}
    }
}
