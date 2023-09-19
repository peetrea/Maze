using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SounsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicVolumeSlider;
    public Slider gameplayVolumeSlider;
    private float musicVolume;
    private float gameplayVolume;
    void Start()
    {
        RestoreVolume();
        SetMusicToggle();   
        SetGameplaySounds();
    }
    public void RestoreVolume()
    {
        float musicVolume = SaveSystem.LoadFloat("musicVolume");
        if (musicVolume != 0f)
        {
            musicVolumeSlider.value = musicVolume;

            float mappedVolume = Mathf.Lerp(-80f, -30f, musicVolume / 100f);
            audioMixer.SetFloat("musicVolume", mappedVolume);
        }

        float gameplayVolume = SaveSystem.LoadFloat("gameplayVolume");
        if (gameplayVolume != 0f)
        {
            gameplayVolumeSlider.value = gameplayVolume;

            float mappedVolume = Mathf.Lerp(-80f, -30f, gameplayVolume / 100f);
            audioMixer.SetFloat("musicVolume", mappedVolume);
        }
    }
    public void SetMusicToggle()
    {
        float volume = musicVolumeSlider.value;
        float mappedVolume = Mathf.Lerp(-80f, -30f, volume / 100f);
        audioMixer.SetFloat("musicVolume", mappedVolume);
        SaveSystem.SaveFloat("musicVolume", volume);
    }
    public void SetGameplaySounds()
    {
        float volume = gameplayVolumeSlider.value;
        float mappedVolume = Mathf.Lerp(-80f, 10f, volume / 100f);
        audioMixer.SetFloat("gameplayVolume", mappedVolume);
        SaveSystem.SaveFloat("gameplayVolume", volume);
    }
}