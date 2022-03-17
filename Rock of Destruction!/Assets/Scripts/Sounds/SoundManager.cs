using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ¬ итоге это нужно удалить

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    //private static Toggle _music;
    //private static Toggle _effects;
    //private static Toggle _vibration;

    public Toggle music;      // просто удалить, после того, как перенесу кнопки
    public Toggle effects;    // просто удалить, после того, как перенесу кнопки
    public Toggle vibration;  // просто удалить, после того, как перенесу кнопки

    [Header("AudioSources")]

    public AudioSource backgroundSource;
    public AudioSource effectsSource;

    [Header("AudioClips")]
    public AudioClip[] background;
    public AudioClip[] people;
    public AudioClip button;



    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        BackgroundSound();
    }

    void Update()
    {

    }
    //public static void Settings(Toggle music, Toggle effects, Toggle vibration)
    //{
    //    _music = music;
    //    _effects = effects;
    //    _vibration = vibration;
    //}

    public void BackgroundSound()
    {
        if (!music.isOn) // Data.Instance.settings.music  воткнуть вот это
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
    public void CollisionSounds(int value)
    {
        if (!effects.isOn)
        {
            switch (value)
            {
                case 0:

                    break;
                case 1:
                    var peopleClip = Random.Range(0, people.Length);
                    //effectsSource.clip = people[peopleClip];
                    effectsSource.PlayOneShot(people[peopleClip]);
                    break;
            }
        }
    }
    public void MuteMusic() //перенести в UI это и все кнопки
    {
        backgroundSource.mute = music.isOn;
        Data.Instance.settings.music = music.isOn;
        //if (_music.isOn)
        //{
        //    backgroundSource.mute = true;
        //}
        //else
        //{
        //    backgroundSource.mute = false;
        //}
    }
    public void MuteEffects()
    {
        effectsSource.mute = effects.isOn;
    }
    public void Vibration()  
    {
        if (!vibration.isOn)
        {
            Handheld.Vibrate();
        }
    }
}
