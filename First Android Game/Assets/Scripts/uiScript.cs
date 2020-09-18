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

    //private AdManager adManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        //adManager = FindObjectOfType<AdManager>().GetComponent<AdManager>();
    }
    void Update()
    {
        scoreText.text = ((int)gameManager.Score).ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //adManager.totalPlayed += 1;
    }
}
