using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdManager : MonoBehaviour
{
    private string playStoreId = "3815271";

    public int totalPlayed = 0;
    public int totalPlayBeforeAds = 3;

    public bool isTestMode;

    public static AdManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        Advertisement.Initialize(playStoreId, isTestMode);
    }
    void Update()
    {
        if(totalPlayed >= totalPlayBeforeAds)
        {
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");
                totalPlayed = 0;
            }           
        }
    }
}
