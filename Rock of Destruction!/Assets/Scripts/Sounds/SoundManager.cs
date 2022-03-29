using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("AudioSources")]
    public AudioSource backgroundSource;
    public AudioSource effectsSource;

    [Header("BackgroundAudioClips")]
    [SerializeField] private AudioClip menuSound;
    [SerializeField] private AudioClip gameSound;

    [Header("UIAudioClips")]
    [SerializeField] private AudioClip buttonSound;

    [Header("PlayerAudioClips")]
    [SerializeField] private AudioClip playerDestruction;
    [SerializeField] private AudioClip playerCollision;

    [Header("PrefabsAudioClips")]
    [SerializeField] private AudioClip[] people;
    [SerializeField] private AudioClip[] animal1;
    [SerializeField] private AudioClip[] animal2;
    [SerializeField] private AudioClip[] animal3;
    [SerializeField] private AudioClip[] tree;
    [SerializeField] private AudioClip[] woodenBuilding;
    [SerializeField] private AudioClip[] stoneBuilding;
    [SerializeField] private AudioClip[] gate;



    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        BackgroundSound();
    }
    private void PlayEffectsClip(AudioClip audioClip)
    {
        if (!Data.Instance.settings.effects)
        {
            effectsSource.PlayOneShot(audioClip);
        }
    }    
    private void PlayMusicClip(AudioClip audioClip)
    {
        if (!Data.Instance.settings.music)
        {
            backgroundSource.clip = audioClip;
            backgroundSource.Play();
        }
    }
    public void BackgroundSound()
    {
        if (Time.timeScale > 0)
        {
            PlayMusicClip(gameSound);
        }
        else
        {
            PlayMusicClip(menuSound);
        }
    }
    public void PlayTabButton()
    {
        PlayEffectsClip(buttonSound);
    }

    public void PrefabDestructionSounds(Audio value)
    {
        switch (value)
        {
            case Audio.None:

                break;

            case Audio.People:
                //var peopleClip = Random.Range(0, people.Length);
                //effectsSource.PlayOneShot(people.[peopleClip]);
                PlayEffectsClip(people.GetRandom());
                break;

            case Audio.Animal1:
                PlayEffectsClip(animal1.GetRandom());
                break;

            case Audio.Animal2:
                PlayEffectsClip(animal2.GetRandom());
                break;

            case Audio.Animal3:
                PlayEffectsClip(animal3.GetRandom());
                break;

            case Audio.Tree:
                PlayEffectsClip(tree.GetRandom());
                break;

            case Audio.WoodenBuilding:
                PlayEffectsClip(woodenBuilding.GetRandom());
                break;

            case Audio.StoneBuilding:
                PlayEffectsClip(stoneBuilding.GetRandom());
                break;

            case Audio.Gate:
                PlayEffectsClip(gate.GetRandom());
                break;

        }
    }
    public void PlayerDestructionSounds()
    {
        PlayEffectsClip(playerDestruction);
    }
    public void PlayerCollisionSounds()
    {
        PlayEffectsClip(playerCollision);
    }
    public void Vibration()  
    {
        if (!Data.Instance.settings.vibration)
        {
            Handheld.Vibrate();
        }
    }
}
