using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameScoreFX : MonoBehaviour
{
    public GameObject checkpointParticle;
    public Transform spawnSpot;

    public void SpawnParticle()
    {
        Instantiate(checkpointParticle, spawnSpot.position, spawnSpot.rotation);
    }
}
