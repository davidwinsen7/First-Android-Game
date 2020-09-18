using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdManager : MonoBehaviour
{
    private string playStoreId = "3815271";
    private string placementId = "Banner";

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
        StartCoroutine(ShowBannerWhenInitialized());
    }
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
        
    }
    void Update()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        if (totalPlayed >= totalPlayBeforeAds)
        {          
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");
                totalPlayed = 0;
            }           
        }
    }
}
