using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardedAdManager : MonoBehaviour
{
    private RewardedAd removeAd;
    public Button removeAdButton;

    // Start is called before the first frame update
    void Start()
    {
        string adUnitId;
        #if UNITY_ANDROID
                adUnitId = "ca-app-pub-3484489003477619/4579794443";
        #elif UNITY_IPHONE
                            adUnitId = "ca-app-pub-3484489003477619/4579794443";
        #else
                            adUnitId = "unexpected_platform";
        #endif

        this.removeAd = new RewardedAd(adUnitId);

        this.removeAd.OnAdOpening += HandleRewardedAdOpening;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.removeAd.LoadAd(request);

        checkNetworkConnection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void checkNetworkConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            removeAdButton.interactable = false;
        }
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        //Activate without Add Session
        PlayerPrefs.SetInt("adActivated", 0);
    }

    public void removeAdsLoaded()
    {
        if (this.removeAd.IsLoaded())
        {
            this.removeAd.Show();
        }
    }
}
