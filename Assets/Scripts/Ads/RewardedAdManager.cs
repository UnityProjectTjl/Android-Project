using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardedAdManager : MonoBehaviour
{
    private RewardedAd rewardedAd;


    // Start is called before the first frame update
    void Start()
    {
        this.rewardedAd = new RewardedAd("ca-app-pub-3940256099942544/5224354917");

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

}
