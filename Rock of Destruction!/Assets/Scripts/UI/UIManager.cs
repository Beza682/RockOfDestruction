using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

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

    [Header("Language")]
    public Toggle language;

    [Header("Audio")]
    public Toggle music;
    public Toggle effects;
    public Toggle vibration;

    private bool Music
    {
        get { return Data.Instance.settings.music; }
        set { Data.Instance.settings.music = value; }
    }
    private bool Effects
    {
        get { return Data.Instance.settings.effects; }
        set { Data.Instance.settings.effects = value; }
    }
    private bool Vibration
    {
        get { return Data.Instance.settings.vibration; }
        set { Data.Instance.settings.vibration = value; }
    }
    private bool Language
    {
        get { return Data.Instance.settings.language; }
        set { Data.Instance.settings.language = value; }
    }
    private void Awake()
    {
        Instance = this;

        //music.isOn = Music;
        //effects.isOn = Effects;
        //vibration.isOn = Vibration;

        //music.isOn = Data.Instance.settings.music;
        //effects.isOn = Data.Instance.settings.effects;
        //vibration.isOn = Data.Instance.settings.vibration;

        Time.timeScale = 0;

        CanvasElementsActivation(true, false, true, false, true, false, false, false, false, false);
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
    }
    private void Start()
    {
        music.isOn = Music;
        effects.isOn = Effects;
        vibration.isOn = Vibration;
        language.isOn = Language;

        //music.isOn = Data.Instance.settings.music;
        //effects.isOn = Data.Instance.settings.effects;
        //vibration.isOn = Data.Instance.settings.vibration;

    }

    private void Update()
    {

    }
    public void SelectedLanguage()
    {
        SoundManager.Instance.PlayTabButton();

        if (!language.isOn)
        {
            LocalizationManager.instance.SetLocalization(SystemLanguage.English);
        }
        else if (language.isOn)
        {
            LocalizationManager.instance.SetLocalization(SystemLanguage.Russian);
        }
    }
    private void CanvasElementsActivation(bool _menu, bool _mainMenu, bool _settings, bool _settingsMenu, bool _start, bool _game, bool _pause, 
        bool _gameOver, bool _skins, bool _achievement)
    {
        menu.SetActive(_menu);
        mainMenu.SetActive(_mainMenu);
        settings.SetActive(_settings);
        settingsMenu.SetActive(_settingsMenu);
        start.SetActive(_start);
        game.SetActive(_game);
        pause.SetActive(_pause);
        gameOver.SetActive(_gameOver);
        skins.SetActive(_skins);
        achievement.SetActive(_achievement);

    }

    public void StrengthUpgradeButtom()
    {
        SoundManager.Instance.PlayTabButton();

    }
    public void SizehUpgradeButtom()
    {
        SoundManager.Instance.PlayTabButton();

    }
    public void OfflineEarningshUpgradeButtom()
    {
        SoundManager.Instance.PlayTabButton();

    }
    public void PlayButtom()
    {
        SoundManager.Instance.PlayTabButton();
        start.SetActive(false);
        menu.SetActive(false);
        settings.SetActive(false);
        game.SetActive(true);
        menuToggle.isOn = false;
        settingsToggle.isOn = false;

        Time.timeScale = 1;       
        SoundManager.Instance.BackgroundSound();

    }

    public void PauseOnButtom()
    {
        SoundManager.Instance.PlayTabButton();
        Time.timeScale = 0;
        SoundManager.Instance.BackgroundSound();

        game.SetActive(false);
        pause.SetActive(true);
        settings.SetActive(true);
    }

    public void PauseOffButtom()
    {
        SoundManager.Instance.PlayTabButton();

        game.SetActive(true);
        pause.SetActive(false);
        settings.SetActive(false);
        settingsToggle.isOn = false;

        Time.timeScale = 1; 
        SoundManager.Instance.BackgroundSound();

    }
    public void MainMenuActivationToggle() 
    {
        SoundManager.Instance.PlayTabButton();
        mainMenu.SetActive(menuToggle.isOn);
    }
    public void SettingsMenuActivationToggle() 
    {
        SoundManager.Instance.PlayTabButton();
        settingsMenu.SetActive(settingsToggle.isOn);
    }
    public void MainMenuButtom()
    {
        SoundManager.Instance.PlayTabButton();

        if (pause)
        {
            pause.SetActive(false);
        }
        SoundManager.Instance.BackgroundSound();
        SceneManager.LoadScene("GameScene");
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        menu.SetActive(false);
        settings.SetActive(false);
        game.SetActive(false);
        menuToggle.isOn = false;
        settingsToggle.isOn = false;
    }
    public void MuteMusicToggle() 
    {
        SoundManager.Instance.PlayTabButton();

        //music.isOn = SoundManager.Instance.backgroundSource.mute;
        //Data.Instance.settings.music = music.isOn;
        //music.isOn = Data.Instance.settings.music;
        Music = music.isOn;
        SoundManager.Instance.backgroundSource.mute = music.isOn;
        SoundManager.Instance.BackgroundSound();

    }
    public void MuteEffectsToggle()
    {
        SoundManager.Instance.PlayTabButton();

        //effects.isOn = SoundManager.Instance.effectsSource.mute;
        //Data.Instance.settings.effects = effects.isOn;
        Effects = effects.isOn;

    }
    public void LanguageToggle()
    {
        SoundManager.Instance.PlayTabButton();

    }
    public void MuteVibrationToggle()
    {
        SoundManager.Instance.PlayTabButton();

        //vibration.isOn = SoundManager.Instance.effectsSource.mute;
        //Data.Instance.settings.vibration = vibration.isOn;
        Vibration = vibration.isOn;
    }
}
