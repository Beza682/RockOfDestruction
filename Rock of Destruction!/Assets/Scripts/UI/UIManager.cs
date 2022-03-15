using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Canvas")]
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

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void Play()
    {
        start.SetActive(false);
        menu.SetActive(false);
        settings.SetActive(false);
        game.SetActive(true);
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
        Time.timeScale = 1;
    }
    public void MainMenuActivation() 
    {
        mainMenu.SetActive(menuToggle.isOn);
        //if (menuToggle.isOn)
        //{
        //    mainMenu.SetActive(true);
        //}
        //else
        //{
        //    mainMenu.SetActive(false);
        //}
    }
    public void SettingsMenuActivation() 
    {
        if (settingsToggle.isOn)
        {
            settingsMenu.SetActive(true);
        }
        else
        {
            settingsMenu.SetActive(false);
        }
    }
    public void MainMenu()
    {
        if (pause)
        {
            pause.SetActive(false);
        }

        SceneManager.LoadScene(0);
    }
}
