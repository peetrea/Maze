using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public LevelsManager levelsManager;
    public GameObject menu;
    public GameObject levelSelection;
    public GameObject coinsLevels;
    public GameObject timeLevels;
    public GameObject levelType;
    public GameObject settings;
    private bool isMusicActivate;
    public AudioMixer audioMixer;
    void Start()
    {
        levelsManager.StartCoinLevel();
        levelsManager.StartTimeLevel();
        levelsManager.UnlockLevels();
        
    }
    void Update()
    {

    }

    public void OpenLevelSelection()
    {
        menu.SetActive(false);
        levelSelection.SetActive(true);
    }
    public void OpenCoinsLevels()
    {
        levelType.SetActive(false);
        coinsLevels.SetActive(true);
    }
    public void OpenTimeLevels()
    {
        levelType.SetActive(false);
        timeLevels.SetActive(true);
    }

    public void BackToMenu()
    {
        levelSelection.SetActive(false);
        settings.SetActive(false);
        menu.SetActive(true);
    }
    public void BackToLevelType()
    {
        timeLevels.SetActive(false);
        coinsLevels.SetActive(false);
        levelType.SetActive(true);
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
        menu.SetActive(true);
    }

    public void StartLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

    public void ExitGame()
    {
        // Ieșiți din aplicație sau joc (funcționează în build-uri standalone)
        Application.Quit();
        Debug.LogError("quit");
    }
    public void MusicToggle()
    {
        Debug.Log(isMusicActivate);
        // Debug.Log((audioMixer.GetFloat("MenuMusic")));
        isMusicActivate = !isMusicActivate;
        if(isMusicActivate)
        {
            audioMixer.SetFloat("musicVolume", -40f);
        }
        else
        {
            audioMixer.SetFloat("musicVolume", -80f);
        }
    }
}
