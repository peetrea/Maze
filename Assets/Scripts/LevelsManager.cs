using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public static LevelsManager instance;
    public Button[] coinLevelsButton;
    public Button[] timeLevelsButton;
    public bool coinsType;
    public bool timeType;
    public int needScore;
    public int Rows;
    public int Columns;
    public int curentLevel;
    public int progressCoins;
    public int progressTime;


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
        progressCoins = SaveSystem.LoadInt("progressCoins");
    }
    private void Start()
    {
        coinsType = false;
        SaveSystem.SaveBool("coinsType", coinsType);
        timeType = false;
        SaveSystem.SaveBool("timeType", timeType);
    }
    private void Update()
    {
        // PlayerPrefs.DeleteAll();
        // Debug.Log("coinsType " + SaveSystem.LoadBool("coinsType"));
        Debug.Log("SaveCurrent " + SaveSystem.LoadInt("curentLevel"));
        // Debug.Log("SaveProgress " + SaveSystem.LoadInt("progressCoins"));
        // Debug.Log("Current " + curentLevel);
        // Debug.Log("Progress " + progressCoins);
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
                        Level1Coin();
                        break;
                    case 1:
                        Level2Coin();
                        break;
                    case 2:
                        Level3Coin();
                        break;
                    case 3:
                        Level4Coin();
                        break;
                    case 4:
                        Level5Coin();
                        break;
                    case 5:
                        Level6Coin();
                        break;
                    case 6:
                        Level7Coin();
                        break;
                    case 7:
                        Level8Coin();
                        break;
                    case 8:
                        Level9Coin();
                        break;
                    case 9:
                        Level10Coin();
                        break;
                    break;
                }
                SaveSystem.SaveInt("Rows", Rows);
                SaveSystem.SaveInt("Columns", Columns);
                SaveSystem.SaveInt("needScore", needScore);
            });
        }
    }
    public void SaveProgress()
    {
        // Debug.Log("Call Save");
        if (progressCoins <= SaveSystem.LoadInt("curentLevel"))
        {
            progressCoins = SaveSystem.LoadInt("curentLevel");
            SaveSystem.SaveInt("progressCoins", progressCoins);
            progressCoins = SaveSystem.LoadInt("progressCoins");
            curentLevel = SaveSystem.LoadInt("curentLevel");
            // Debug.Log("Saved");
        }
    }

    public void UnlockLevels()
    {
        for (int i = 0; i < coinLevelsButton.Length; i++)
        {
            if (i <= progressCoins)
            {
                coinLevelsButton[i].interactable = true;
            }
            else
            {
                coinLevelsButton[i].interactable = false;
            }
        }
    }

    public void Level1Coin()
    {
        Rows = 10;
        Columns = 10;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level2Coin()
    {
        Rows = 15;
        Columns = 15;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level3Coin()
    {
        Rows = 20;
        Columns = 20;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level4Coin()
    {
        Rows = 20;
        Columns = 20;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level5Coin()
    {
        Rows = 20;
        Columns = 20;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level6Coin()
    {
        Rows = 20;
        Columns = 20;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level7Coin()
    {
        Rows = 20;
        Columns = 20;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level8Coin()
    {
        Rows = 20;
        Columns = 20;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level9Coin()
    {
        Rows = 20;
        Columns = 20;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }
    public void Level10Coin()
    {
        Rows = 20;
        Columns = 20;
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        needScore = 0;
    }

}
