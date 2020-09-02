using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum gameState
    {
        Standby, Gameplay, GameOver
    }

    [Range(0f,5f)]
    public float spawnSpeed = 3f;
    [Range(0f, 5f)]
    public float obstacleSpeed = 2f;

    [HideInInspector]
    public float Score = 0f;

    public gameState state = gameState.Standby;


    [Header("UI Management")]
    public GameObject gameoverUI;
    private void Update()
    {
        if(state == gameState.GameOver)
        {
            Time.timeScale = 0f;
            gameoverUI.SetActive(true);
            Debug.Log("Game OVER!!");
        }
        else if(state == gameState.Gameplay)
        {
            Time.timeScale = 1f;
            Score += 5*Time.deltaTime;
            
        }
        else if(state == gameState.Standby)
        {
            Time.timeScale = 1f;
        }
    }
}
