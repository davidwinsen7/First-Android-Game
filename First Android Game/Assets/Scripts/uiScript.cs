using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class uiScript : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI scoreText;
    public GameObject settingsUI;
    public GameObject creditsUI;

    private AudioManager auManager;

    //private AdManager adManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        auManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        //adManager = FindObjectOfType<AdManager>().GetComponent<AdManager>();
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

    public void closeCredits()
    {
        creditsUI.SetActive(false);
        auManager.Play("buttonTap");
    }
}
