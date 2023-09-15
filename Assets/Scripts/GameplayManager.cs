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
    public int needScore;
    void Start()
    {
        needScore = SaveSystem.LoadInt("needScore");
        ResumeGame();
        // Debug.Log(SaveSystem.LoadInt("curentLevel"));
        // Debug.Log(SaveSystem.LoadInt("progressCoins"));
    }

    void Update()
    {
        ShowScore();
        SwitchPause();
    }
     public void CeckWin()
    {
        if (score >= needScore)
        {
            ShowWinPanel();
            LevelsManager.instance.SaveProgress();
        }
    }
    public void FinishLevel()
    {
   
    }
    private void ShowWinPanel()
    {
        WinPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseGame();
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
        PausePanel.SetActive(true);
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
                score = 100;
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
            }
            else if (SaveSystem.LoadBool("timeType"))
            {
                score = 100;
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
   

    private void LoadLevel(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}