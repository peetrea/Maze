using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveBool(string key, bool value)
    {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public static bool LoadBool(string key)
    {
        int savedValue = PlayerPrefs.GetInt(key, 0);
        return savedValue == 1;
    }

    public static void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int LoadInt(string key)
    {
        return PlayerPrefs.GetInt(key, 0);
    }

    public static void SaveFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static float LoadFloat(string key)
    {
        return PlayerPrefs.GetFloat(key, 0.0f);
    }

    public static void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public static string LoadString(string key)
    {
        return PlayerPrefs.GetString(key, "");
    }

    public static void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}

