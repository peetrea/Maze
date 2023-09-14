using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public LevelsManager levelsManager;
    public GameObject menu;
    public GameObject levelSelection;
    public GameObject coinsLevels;
    public GameObject timeLevels;
    public GameObject levelType;
    public GameObject settings;
    void Start()
    {
        levelsManager.StartCoinLevel();
        
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
}
