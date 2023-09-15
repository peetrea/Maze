using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
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
    public TextMeshProUGUI timerText;
    public float startTime;
    public float curentTime;
    private bool isRunning;
    public int needScore;
    void Start()
    {
        startTime = SaveSystem.LoadFloat("startTime");
        needScore = SaveSystem.LoadInt("needScore");
        curentTime = startTime;
        isRunning = true;
        ResumeGame();
    }

    void Update()
    {
        ShowScore();
        SwitchPause();
        TimerDecrement();
    }
     public void CeckWin()
    {
        if (SaveSystem.LoadBool("coinsType"))
        {
            if (score >= needScore)
            {
                FinishLevel();
            }
        }
        else if (SaveSystem.LoadBool("timeType"))
        {
            FinishLevel();
        }
    }
    public void FinishLevel()
    {
        LevelsManager.instance.SaveProgress();
        ShowWinPanel();
        PauseGame();
    }
    private void ShowWinPanel()
    {
        WinPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Lose()
    {
        ShowLosePanel();
        PauseGame();
        PausePanel.SetActive(false);
    }
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
            }
            else
            {
                ResumeGame();
            }
        }
    }
    public void PauseGame()
    {
        PausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        isGamePaused = true;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        SaveSystem.SaveBool("coinsType", false);
        SaveSystem.SaveBool("timeType", false);
        // ResumeGame();
    }
    public void Restart()
    {
        for (int i = 1; i <= SaveSystem.LoadInt("curentLevel"); i++)
        {
            SceneManager.LoadScene("GamePlay");
            if(SaveSystem.LoadBool("coinsType"))
            {
                score = 0;
                switch(SaveSystem.LoadInt("curentLevel"))
                {
                    case 1:
                        LevelsManager.instance.Level1Coin();
                        break;
                    case 2:
                        LevelsManager.instance.Level2Coin();
                        break;
                    case 3:
                        LevelsManager.instance.Level3Coin();
                        break;
                    case 4:
                        LevelsManager.instance.Level4Coin();
                        break;
                    case 5:
                        LevelsManager.instance.Level5Coin();
                        break;
                    case 6:
                        LevelsManager.instance.Level6Coin();
                        break;
                    case 7:
                        LevelsManager.instance.Level7Coin();
                        break;
                    case 8:
                        LevelsManager.instance.Level8Coin();
                        break;
                    case 9:
                        LevelsManager.instance.Level9Coin();
                        break;
                    case 10:
                        LevelsManager.instance.Level10Coin();
                        break;
                    break;
                }
            }
            else if (SaveSystem.LoadBool("timeType"))
            {
                switch(SaveSystem.LoadInt("curentLevel"))
                {
                    case 1:
                        LevelsManager.instance.Level1Time();
                        break;
                    case 2:
                        LevelsManager.instance.Level2Time();
                        break;
                    case 3:
                        LevelsManager.instance.Level3Time();
                        break;
                    case 4:
                        LevelsManager.instance.Level4Time();
                        break;
                    case 5:
                        LevelsManager.instance.Level5Time();
                        break;
                    case 6:
                        LevelsManager.instance.Level6Time();
                        break;
                    case 7:
                        LevelsManager.instance.Level7Time();
                        break;
                    case 8:
                        LevelsManager.instance.Level8Time();
                        break;
                    case 9:
                        LevelsManager.instance.Level9Time();
                        break;
                    case 10:
                        LevelsManager.instance.Level10Time();
                        break;
                    break;
                }
            }
        }
        ResumeGame();
    }
    public void NextLevel()
    {
        int curentLevel = SaveSystem.LoadInt("curentLevel");
        curentLevel++;
        if (curentLevel > LevelsManager.instance.coinLevelsButton.Length)
        {
            Debug.Log("Ai terminat toate nivelurile disponibile!");
        }
        else
        {
            SceneManager.LoadScene("GamePlay");
            SaveSystem.SaveInt("curentLevel", curentLevel);
        }
            if(SaveSystem.LoadBool("coinsType"))
            {
                switch(SaveSystem.LoadInt("curentLevel"))
                {
                    case 1:
                        LevelsManager.instance.Level1Coin();
                        Debug.Log("Level1");
                        break;
                    case 2:
                        LevelsManager.instance.Level2Coin();
                        Debug.Log("Level2");
                        break;
                    case 3:
                        LevelsManager.instance.Level3Coin();
                        Debug.Log("Level3");
                        break;
                    case 4:
                        LevelsManager.instance.Level4Coin();
                        Debug.Log("Level4");
                        break;
                    case 5:
                        LevelsManager.instance.Level5Coin();
                        Debug.Log("Level5");
                        break;
                    case 6:
                        LevelsManager.instance.Level6Coin();
                        Debug.Log("Level6");
                        break;
                    case 7:
                        LevelsManager.instance.Level7Coin();
                        Debug.Log("Level7");
                        break;
                    case 8:
                        LevelsManager.instance.Level8Coin();
                        Debug.Log("Level8");
                        break;
                    case 9:
                        LevelsManager.instance.Level9Coin();
                        Debug.Log("Level9");
                        break;
                    case 10:
                        LevelsManager.instance.Level10Coin();
                        Debug.Log("Level10");
                        break;
                    break;
                }
                LevelsManager.instance.SaveForCoins();
            }
            else if (SaveSystem.LoadBool("timeType"))
            {
                switch(SaveSystem.LoadInt("curentLevel"))
                {
                    case 1:
                        LevelsManager.instance.Level1Time();
                        break;
                    case 2:
                        LevelsManager.instance.Level2Time();
                        break;
                    case 3:
                        LevelsManager.instance.Level3Time();
                        break;
                    case 4:
                        LevelsManager.instance.Level4Time();
                        break;
                    case 5:
                        LevelsManager.instance.Level5Time();
                        break;
                    case 6:
                        LevelsManager.instance.Level6Time();
                        break;
                    case 7:
                        LevelsManager.instance.Level7Time();
                        break;
                    case 8:
                        LevelsManager.instance.Level8Time();
                        break;
                    case 9:
                        LevelsManager.instance.Level9Time();
                        break;
                    case 10:
                        LevelsManager.instance.Level10Time();
                        break;
                    break;
                }
                LevelsManager.instance.SaveForTime();
            }
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
    public void TimerDecrement()
    {
        if (isRunning)
        {
            if (SaveSystem.LoadBool("timeType"))
            {
                curentTime -= Time.deltaTime;

                if (curentTime <= 0)
                {
                    curentTime = 0;
                    Lose();
                }
            }
            else if (SaveSystem.LoadBool("coinsType"))
            {
                curentTime += Time.deltaTime;
            }
            int minutes = Mathf.FloorToInt(curentTime / 60);
            int seconds = Mathf.FloorToInt(curentTime % 60);

            timerText.text = String.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }
   

    private void LoadLevel(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}