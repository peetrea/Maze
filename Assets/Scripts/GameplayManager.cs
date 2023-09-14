using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    // private ScoreDisplay scoreDisplay;
    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject PausePanel;
    private bool isGamePaused = false;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        // scoreDisplay = FindObjectOfType<ScoreDisplay>();
        // SetScore();
        ResumeGame();
    }

    void Update()
    {
        // scoreDisplay.UpdateScoreText();
        // FinishLevel();
        ShowScore();
        SwitchPause();
    }
    // public void FinishLevel()
    // {
    //     if (GlobalManager.Instance.score <= 0)
    //     {
    //         GlobalManager.Instance.score = 0;
    //         PauseGame();
    //         ShowWinPanel();
    //     }
    // }
    // private void ShowWinPanel()
    // {
    //     WinPanel.SetActive(true);
    //     if (GlobalManager.Instance.curentLevel >= GlobalManager.Instance.progres)
    //     {
    //         GlobalManager.Instance.progres = GlobalManager.Instance.curentLevel;
    //     }
    // }
    public void ShowLosePanel()
    {
        LosePanel.SetActive(true);
    }
    public void SwitchPause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isGamePaused)
            {
                PauseGame();
                PausePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                ResumeGame();
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
    public void PauseGame()
    {
        Debug.Log("apelled");
        Time.timeScale = 0f;
        isGamePaused = true;
        PausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        PausePanel.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        ResumeGame();
    }
    public void Restart()
    {
        ResumeGame();
    }
    public void IncremenentScore()
    {
        score += 1;
    }
    private void ShowScore()
    {
        scoreText.text = score.ToString();
    }
    public void Win()
    {
        if (score == 10)
        {
            
        }
    }
    // private void SetScore()
    // {
    //     switch (GlobalManager.Instance.curentLevel)
    //     {
    //         case 1:
    //             GlobalManager.Instance.score = 10;
    //             break;
    //         case 2:
    //             GlobalManager.Instance.score = 10;
    //             break;
    //         case 3:
    //             GlobalManager.Instance.score = 20;
    //             break;
    //         case 4:
    //             GlobalManager.Instance.score = 20;
    //             break;
    //         case 5:
    //             GlobalManager.Instance.score = 30;
    //             break;
    //         case 6:
    //             GlobalManager.Instance.score = 20;
    //             break;
    //         case 7:
    //             GlobalManager.Instance.score = 20;
    //             break;
    //         case 8:
    //             GlobalManager.Instance.score = 30;
    //             break;
    //         case 9:
    //             GlobalManager.Instance.score = 30;
    //             break;
    //         case 10:
    //             GlobalManager.Instance.score = 40;
    //             break;
    //     }
    // }
    // public void NextLevel()
    // {
    //     Time.timeScale = 1f;
    //     switch(GlobalManager.Instance.curentLevel)
    //     {
    //         case 1:
    //         LoadLevel("Level 2");
    //         GlobalManager.Instance.curentLevel = 2;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //         case 2:
    //         LoadLevel("Level 3");
    //         GlobalManager.Instance.curentLevel = 3;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //         case 3:
    //         LoadLevel("Level 4");
    //         GlobalManager.Instance.curentLevel = 4;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //         case 4:
    //         LoadLevel("Level 5");
    //         GlobalManager.Instance.curentLevel = 5;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //         case 5:
    //         LoadLevel("Level 6");
    //         GlobalManager.Instance.curentLevel = 6;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //         case 6:
    //         LoadLevel("Level 7");
    //         GlobalManager.Instance.curentLevel = 7;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //         case 7:
    //         LoadLevel("Level 8");
    //         GlobalManager.Instance.curentLevel = 8;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //         case 8:
    //         LoadLevel("Level 9");
    //         GlobalManager.Instance.curentLevel = 9;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //         case 9:
    //         LoadLevel("Level 10");
    //         GlobalManager.Instance.curentLevel = 10;
    //         // GlobalManager.Instance.score = 10;
    //         ResumeGame();
    //         break;
    //     }
    // }
    private void LoadLevel(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}