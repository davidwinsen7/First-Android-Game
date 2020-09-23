using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class FingerInput : MonoBehaviour
{
    GameManager gameManager;
    TrailRenderer trail;
    public GameObject touchToPlayUI;

    private AudioManager auManager;
    private AdManager adManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        trail = GetComponent<TrailRenderer>();
        auManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        adManager = FindObjectOfType<AdManager>().GetComponent<AdManager>();
        auManager.Play("Standby"); //Play standby Music in audiomanager
    }
    void Update()
    {
        if (gameManager.state == GameManager.gameState.GameOver)
            auManager.Stop("Gameplay");

        if(Input.touchCount > 0) //Check if there's any touch input
        {           
            Touch touch = Input.GetTouch(0); //get the touch input from the first finger
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position); //get the finger position
            touchPos.z = 0f;

            if(gameManager.state == GameManager.gameState.Gameplay)
                transform.position = touchPos; //set object position to follow finger position

            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId)) //Ignore touch input over UI e.g. button
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Debug.Log("Touch Began");
                        if (gameManager.state == GameManager.gameState.Standby)
                        {
                            gameManager.state = GameManager.gameState.Gameplay;
                            auManager.Stop("Standby");
                            auManager.Play("swoosh");
                            auManager.Play("Gameplay");
                        }

                        touchToPlayUI.SetActive(false);
                        break;
                    case TouchPhase.Ended:
                        Debug.Log("Touch Ended");
                        if (gameManager.state == GameManager.gameState.Gameplay)
                        {
                            adManager.totalPlayed += 1;
                            gameManager.state = GameManager.gameState.GameOver;
                            trail.enabled = false;
                        }
                        break;
                }
            }           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //Debug.Log("Collided with an obstacle!");
            auManager.Play("obstacleHit");
            adManager.totalPlayed += 1;               
            gameManager.state = GameManager.gameState.GameOver;
            
            Handheld.Vibrate(); //Vibrate device when colliding with obstacles
            trail.enabled = false; //disable trail effect when gameover
        }
    }
}
