using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // private TotalScore totalScore;
    public GameObject menu;
    public GameObject levelSelection;
    public GameObject settings;
    void Start()
    {
        // totalScore = FindObjectOfType<TotalScore>();
        
    }
    void Update()
    {
        // totalScore.UpdateTotalScoreText();
    }

    public void OpenLevelSelection()
    {
        menu.SetActive(false);
        levelSelection.SetActive(true);
    }

    public void CloseLevelSelection()
    {
        levelSelection.SetActive(false);
        settings.SetActive(false);
        menu.SetActive(true);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");
        // GlobalManager.Instance.score = 10;
    }

    public void ExitGame()
    {
        // Ieșiți din aplicație sau joc (funcționează în build-uri standalone)
        Application.Quit();
        Debug.LogError("quit");
    }
}
