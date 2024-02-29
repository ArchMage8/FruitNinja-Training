using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    private GameObject HUD;
    public AudioMixer audioMixer;
    public GameObject blade;

    public float ChangeScale = 1;

    private void Awake()
    {
        HUD = GameObject.Find("HUD");
        HUD.SetActive(false);
        mainMenu.SetActive(true);

        Time.timeScale = 0f;
        blade.SetActive(false);
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1f;   
        blade.SetActive(true);
        HUD.SetActive(true);
    }

    public void IncreaseMusic()
    {
        audioMixer.GetFloat("MusicVol", out float currentVolume);

        
        
        if (currentVolume <= 20f)
        {
            
            currentVolume = currentVolume + Mathf.Log10(ChangeScale * 20);
            audioMixer.SetFloat("MusicVol", currentVolume);

            Debug.Log("Music Increase");
            Debug.Log(currentVolume);
        }

    }

    public void DecreaseMusic()
    {
        audioMixer.GetFloat("MusicVol", out float currentVolume);
        if (currentVolume >= -20f)
        {
            currentVolume = currentVolume - Mathf.Log10(ChangeScale * 20); ;
            audioMixer.SetFloat("MusicVol", currentVolume);


            Debug.Log("Music Decrease");
            Debug.Log(currentVolume);
        }
    }

    public void IncreaseSFX()
    {
        audioMixer.GetFloat("SFXVol", out float currentVolume);
        if (currentVolume <= 20f)
        {
            currentVolume = currentVolume + Mathf.Log10(ChangeScale * 20);
            audioMixer.SetFloat("SFXVol", currentVolume);


            Debug.Log("SFX Increase");
        }
    }

    public void DecreaseSFX()
    {
        audioMixer.GetFloat("SFXVol", out float currentVolume);
        if (currentVolume >= -20f)
        {
            currentVolume = currentVolume - Mathf.Log10(ChangeScale * 20);
            audioMixer.SetFloat("SFXVol", currentVolume);


            Debug.Log("SFX Decrease");
        }
    }

}
