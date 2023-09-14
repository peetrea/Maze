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
        Debug.Log(SaveSystem.LoadInt("curentLevel"));
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
        // ResumeGame();
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
   

    private void LoadLevel(string levelName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}