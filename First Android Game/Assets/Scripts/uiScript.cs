using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class uiScript : MonoBehaviour
{
    GameManager gameManager;
    private settingsValue settingsVal;
    public TextMeshProUGUI scoreText;
    public GameObject settingsUI;
    public GameObject creditsUI;

    private AudioManager auManager;

    public Toggle music_toggle;
    public AudioMixer music;
    public Toggle SFX_toggle;
    public AudioMixer SFX;
    //private AdManager adManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        auManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        //adManager = FindObjectOfType<AdManager>().GetComponent<AdManager>();
        settingsVal = FindObjectOfType<settingsValue>().GetComponent<settingsValue>();
        music_toggle.isOn = settingsVal.music;
        SFX_toggle.isOn = settingsVal.SFX;
    }
    void Update()
    {
        scoreText.text = ((int)gameManager.Score).ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        auManager.Play("buttonTap");
        //adManager.totalPlayed += 1;
    }
    public void backFromSettings()
    {
        settingsUI.SetActive(false);
        auManager.Play("buttonTap");
    }
    public void openSettings()
    {
        settingsUI.SetActive(true);
        auManager.Play("buttonTap");
    }

    public void openCredits()
    {
        creditsUI.SetActive(true);
        auManager.Play("buttonTap");
    }

    public void openSupportPage()
    {
        Application.OpenURL("https://davidwinsen7.wixsite.com/site/jet-finger/jet-finger-support");
    }

    public void closeCredits()
    {
        creditsUI.SetActive(false);
        auManager.Play("buttonTap");
    }

    public void musicToggle(bool toggle)
    {
        settingsVal.music = toggle;
        float volume;
        music.GetFloat("MusicVol", out volume);
        if (!toggle && volume == 0f)
        {
            music.SetFloat("MusicVol", -80f);
        }
        else if(toggle && volume < 0f)
        {
            music.SetFloat("MusicVol", 0f);
        }
    }

    public void sfxToggle(bool toggle)
    {
        settingsVal.SFX = toggle;
        float volume;
        SFX.GetFloat("SFXVol", out volume);
        if(!toggle && volume == 0f)
        {
            SFX.SetFloat("SFXVol", -80f);
        }
        else if(toggle && volume < 0f)
        {
            SFX.SetFloat("SFXVol", 0f);
        }
    }
}
