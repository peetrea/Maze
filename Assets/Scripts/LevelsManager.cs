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
    public float startTime;
    public int Enemys;
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
        progressTime = SaveSystem.LoadInt("progressTime");
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
        // Debug.Log("timeType " + SaveSystem.LoadBool("timeType"));
        // Debug.Log("SaveCurrent " + SaveSystem.LoadInt("curentLevel"));
        // Debug.Log("SaveProgress " + SaveSystem.LoadInt("progressCoins"));
        // Debug.Log("Current " + curentLevel);
        // Debug.Log("Progress " + progressCoins);
    }

    public void StartTimeLevel()
    {
        for (int i = 0; i < timeLevelsButton.Length; i++)
        {
            int levelIndex = i;

            timeLevelsButton[i].onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GamePlay");
                timeType = true;
                SaveSystem.SaveBool("timeType", timeType);
                curentLevel = levelIndex + 1;
                SaveSystem.SaveInt("curentLevel", curentLevel);
                
                switch(levelIndex)
                {
                    case 0:
                        Level1Time();
                        Debug.Log("level1");
                        break;
                    case 1:
                        Level2Time();
                        Debug.Log("level2");
                        break;
                    case 2:
                        Level3Time();
                        Debug.Log("level3");
                        break;
                    case 3:
                        Level4Time();
                        Debug.Log("level4");
                        break;
                    case 4:
                        Level5Time();
                        break;
                    case 5:
                        Level6Time();
                        Debug.Log("level6");
                        break;
                    case 6:
                        Level7Time();
                        Debug.Log("level7");
                        break;
                    case 7:
                        Level8Time();
                        Debug.Log("level8");
                        break;
                    case 8:
                        Level9Time();
                        Debug.Log("level9");
                        break;
                    case 9:
                        Level10Time();
                        Debug.Log("level10");
                        break;
                    break;
                }
                SaveForTime();
            });
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
                startTime = 0f;
                
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
                SaveForCoins();
            });
        }
    }
    public void SaveForCoins()
    {
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        SaveSystem.SaveInt("needScore", needScore);
        SaveSystem.SaveInt("Enemys", Enemys);
        SaveSystem.SaveFloat("startTime", startTime);
    }
    public void SaveForTime()
    {
        SaveSystem.SaveInt("Rows", Rows);
        SaveSystem.SaveInt("Columns", Columns);
        SaveSystem.SaveFloat("startTime", startTime);
        SaveSystem.SaveInt("Enemys", Enemys);
    }
    public void SaveProgress()
    {
        if (progressCoins <= SaveSystem.LoadInt("curentLevel"))
        {
            progressCoins = SaveSystem.LoadInt("curentLevel");
            SaveSystem.SaveInt("progressCoins", progressCoins);
            progressCoins = SaveSystem.LoadInt("progressCoins");
            curentLevel = SaveSystem.LoadInt("curentLevel");
        }
        if (progressTime <= SaveSystem.LoadInt("curentLevel"))
        {
            progressTime = SaveSystem.LoadInt("curentLevel");
            SaveSystem.SaveInt("progressTime", progressTime);
            progressTime = SaveSystem.LoadInt("progressTime");
            curentLevel = SaveSystem.LoadInt("curentLevel");
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
        for (int i = 0; i < timeLevelsButton.Length; i++)
        {
            if (i <= progressTime)
            {
                timeLevelsButton[i].interactable = true;
            }
            else
            {
                timeLevelsButton[i].interactable = false;
            }
        }
    }

    public void Level1Time()
    {
        Rows = 10;
        Columns = 10;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 60f;
    }
    public void Level2Time()
    {
        Rows = 15;
        Columns = 15;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 70f;
    }
    public void Level3Time()
    {
        Rows = 20;
        Columns = 20;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 80f;
    }
    public void Level4Time()
    {
        Rows = 20;
        Columns = 20;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 90f;
    }
    public void Level5Time()
    {
        Rows = 25;
        Columns = 25;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 100f;
    }
    public void Level6Time()
    {
        Rows = 25;
        Columns = 25;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 110f;
    }
    public void Level7Time()
    {
        Rows = 30;
        Columns = 30;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 120f;
    }
    public void Level8Time()
    {
        Rows = 30;
        Columns = 30;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 130f;
    }
    public void Level9Time()
    {
        Rows = 35;
        Columns = 35;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 140f;
    }
    public void Level10Time()
    {
        Rows = 35;
        Columns = 35;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        startTime = 150f;
    }
    public void Level1Coin()
    {
        Rows = 10;
        Columns = 10;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 10;
    }
    public void Level2Coin()
    {
        Rows = 15;
        Columns = 15;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 15;
    }
    public void Level3Coin()
    {
        Rows = 20;
        Columns = 20;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 20;
    }
    public void Level4Coin()
    {
        Rows = 20;
        Columns = 20;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 20;
    }
    public void Level5Coin()
    {
        Rows = 25;
        Columns = 25;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 25;
    }
    public void Level6Coin()
    {
        Rows = 25;
        Columns = 25;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 25;
    }
    public void Level7Coin()
    {
        Rows = 30;
        Columns = 30;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 30;
    }
    public void Level8Coin()
    {
        Rows = 30;
        Columns = 30;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 30;
    }
    public void Level9Coin()
    {
        Rows = 35;
        Columns = 35;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 35;
    }
    public void Level10Coin()
    {
        Rows = 35;
        Columns = 35;
        Enemys = SaveSystem.LoadInt("curentLevel") * 5;
        needScore = 40;
    }

}
