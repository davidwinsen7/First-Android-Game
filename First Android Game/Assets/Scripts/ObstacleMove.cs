using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    private float speed;
    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    void Update()
    {
        speed = gameManager.obstacleSpeed;
        transform.Translate(0f, -speed * Time.deltaTime, 0f);
    }
}
