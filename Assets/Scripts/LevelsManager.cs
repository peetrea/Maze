using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    private static LevelsManager instance;
    public Button[] coinLevelsButton;
    public Button[] timeLevelsButton;
    public bool coinsType;
    public bool timeType;
    public int needScore;
    public int Rows;
    public int Columns;
    public int curentLevel;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartCoinLevel()
    {
        for (int i = 0; i < coinLevelsButton.Length; i++)
        {
            int levelIndex = i;

            coinLevelsButton[i].onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GamePlay");
                coinsType = true;
                SaveSystem.SaveBool("coinsType", coinsType);
                curentLevel = levelIndex + 1;
                SaveSystem.SaveInt("curentLevel", curentLevel);
                switch(levelIndex)
                {
                    case 0:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        Rows = 10;
                        Columns = 10;
                        needScore = 0;
                        break;
                    case 1:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        Rows = 15;
                        Columns = 15;
                        needScore = 15;
                        break;
                    case 2:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        Rows = 20;
                        Columns = 20;
                        needScore = 20;
                        break;
                    case 3:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        Rows = 20;
                        Columns = 20;
                        needScore = 20;
                        break;
                    case 4:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        needScore = 10;
                        break;
                    case 5:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        needScore = 10;
                        break;
                    case 6:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        needScore = 10;
                        break;
                    case 7:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        needScore = 10;
                        break;
                    case 8:
                    Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        needScore = 10;
                        break;
                    case 9:
                        Debug.Log("Butonul pentru nivelul " + (levelIndex + 1) + " a fost apăsat.");
                        needScore = 10;
                        break;
                    break;
                }
                SaveSystem.SaveInt("Rows", Rows);
                SaveSystem.SaveInt("Columns", Columns);
                SaveSystem.SaveInt("needScore", needScore);
            });
        }
    }
}
