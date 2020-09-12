using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public enum gameState
    {
        Standby, Gameplay, GameOver
    }

    [Range(0f,5f)]
    public float obstacleSpawnSpeed = 3f;
    [Range(0f, 5f)]
    public float obstacleSpeed = 2f;

    [HideInInspector] public float Score = 0f;

    public gameState state = gameState.Standby;


    [Header("UI Management")]
    public GameObject gameoverUI;
    public GameObject titleText;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI startGameHighScore;
    public TextMeshProUGUI endingScore;
    public GameObject newHighScoreNotice;

    private void Start()
    {
        startGameHighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //Show high score in the start screen
    }
    private void Update()
    {
        if(state == gameState.GameOver)
        {
            Time.timeScale = 0f;
            gameoverUI.SetActive(true);
            endingScore.text = ((int)Score).ToString(); //Show score when gameover 
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString(); //Show previous highscore if not beaten
            if (Score > PlayerPrefs.GetInt("HighScore", 0)) //update highscore if new score > previous high score
            {
                PlayerPrefs.SetInt("HighScore", (int)Score);
                highScore.text = ((int)Score).ToString();
                newHighScoreNotice.SetActive(true);
            }
            //Debug.Log("Game OVER!!");
        }
        else if(state == gameState.Gameplay)
        {
            Time.timeScale = 1f;
            startGameHighScore.transform.parent.gameObject.SetActive(false);
            titleText.SetActive(false);
            FindObjectOfType<uiScript>().GetComponent<uiScript>().scoreText.gameObject.SetActive(true);
            Score += 5*Time.deltaTime;
            
        }
        else if(state == gameState.Standby)
        {
            Time.timeScale = 1f;
            FindObjectOfType<uiScript>().GetComponent<uiScript>().scoreText.gameObject.SetActive(false);
        }
    }
}
