using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject menu;
    public Toggle menuToggle;
    public GameObject mainMenu;

    public GameObject settings;
    public Toggle settingsToggle;
    public GameObject settingsMenu;

    public GameObject start;    
    public GameObject game;
    public GameObject pause;
    public GameObject gameOver;
    public GameObject skins;
    public GameObject achievement;

    [Header("Audio")]
    public Toggle music;
    public Toggle effects;
    public Toggle vibration;

    private bool Music
    {
        get { return Data.Instance.settings.music; }
        set { Data.Instance.settings.music = value; }
    }

    private void Awake()
    {

        //SoundManager.Instance.music.isOn = music.isOn;
        //music.isOn = Music;
        Time.timeScale = 0;


        menu.SetActive(true);
        mainMenu.SetActive(false);
        settings.SetActive(true);
        settingsMenu.SetActive(false);
        start.SetActive(true);
        game.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(false);
        skins.SetActive(false);
        achievement.SetActive(false);


        //music.isOn = Data.Instance.settings.music;
        //Debug.Log(music.isOn);

        //SoundManager.Settings(music, effects, vibration);
    }
    private void Start()
    {
        //music.isOn = Data.Instance.settings.music;

        SoundManager.Instance.music = music;
        SoundManager.Instance.effects = effects;
        SoundManager.Instance.vibration = vibration;

        //Debug.Log(music.isOn);
    }

    private void Update()
    {
        //Data.Instance.settings.music = music.isOn;

        //SoundManager.Instance.music = music;
        //SoundManager.Instance.effects = effects;
        //SoundManager.Instance.vibration = vibration;
        //Music = music.isOn;


        //Data.Instance.settings.music = music.isOn;

        //Debug.Log(Data.Instance.settings.music);

    }
    public void Play()
    {
        start.SetActive(false);
        menu.SetActive(false);
        settings.SetActive(false);
        game.SetActive(true);
        menuToggle.isOn = false;
        settingsToggle.isOn = false;
        Time.timeScale = 1;
    }

    public void PauseOn()
    {
        Time.timeScale = 0;
        game.SetActive(false);
        pause.SetActive(true);
        settings.SetActive(true);
    }

    public void PauseOff()
    {
        game.SetActive(true);
        pause.SetActive(false);
        settings.SetActive(false);
        settingsToggle.isOn = false;
        Time.timeScale = 1;
    }
    public void MainMenuActivation() 
    {
        mainMenu.SetActive(menuToggle.isOn);
    }
    public void SettingsMenuActivation() 
    {
        settingsMenu.SetActive(settingsToggle.isOn);
    }
    public void MainMenu()
    {
        if (pause)
        {
            pause.SetActive(false);
        }

        SceneManager.LoadScene("LoadScene");
    }
}
