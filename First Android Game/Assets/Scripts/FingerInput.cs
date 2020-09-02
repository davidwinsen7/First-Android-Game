using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerInput : MonoBehaviour
{
    GameManager gameManager;
    TrailRenderer trail;
    public GameObject touchToPlayUI;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        trail = GetComponent<TrailRenderer>();
        
    }
    void Update()
    {
        if(Input.touchCount > 0) //Check if there's any touch input
        {
            Touch touch = Input.GetTouch(0); //get the touch input from the first finger
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position); //get the finger position
            touchPos.z = 0f;

            transform.position = touchPos; //set object position to follow finger position

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Touch Began");
                    if(gameManager.state == GameManager.gameState.Standby)
                        gameManager.state = GameManager.gameState.Gameplay;
                    touchToPlayUI.SetActive(false);
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Ended");
                    gameManager.state = GameManager.gameState.GameOver;
                    trail.enabled = false;
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Debug.Log("Collided with an obstacle!");
            gameManager.state = GameManager.gameState.GameOver;
            trail.enabled = false; //disable trail effect when gameover
        }
    }
}
