using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    [Range(1f,5f)]
    private float spawnDelay;
    private int obstacleIndex;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        
    }

    bool isSpawning = false;

    private void Update()
    {
        if(gameManager.state == GameManager.gameState.Gameplay && isSpawning == false)
        {
            StartCoroutine(Spawn());
            isSpawning = true;
        }
        else if(gameManager.state != GameManager.gameState.Gameplay)
        {
            StopAllCoroutines();
            isSpawning = false;
        }
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            spawnDelay = gameManager.spawnSpeed;
            obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
