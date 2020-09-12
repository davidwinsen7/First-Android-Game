using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float minSpawnDelay = 2f;
    public float maxSpawnDelay = 5f;
    public float spawnXLimit = 4f;

    private void Start()
    {
        Spawn();
    }
    void Spawn()
    {
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(cloudPrefab, spawnPos, Quaternion.identity);

        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
