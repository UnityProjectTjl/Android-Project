using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardedAdManager : MonoBehaviour
{
    private RewardedAd CoinsAd1000;
    private RewardedAd CoinsAd5000;
    private RewardedAd CoinsAd10000;
    public Button buyButton1;
    public Button buyButton2;
    public Button buyButton3;


    // Start is called before the first frame update
    void Start()
    {
        string adUnitId;
        #if UNITY_ANDROID
                adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
                    adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
                    adUnitId = "unexpected_platform";
        #endif


        this.CoinsAd1000 = new RewardedAd(adUnitId);
        this.CoinsAd5000 = new RewardedAd(adUnitId);
        this.CoinsAd10000 = new RewardedAd(adUnitId);

    }

    public RewardedAd CreateAndLoadRewardedAd(string adUnitId)
    {
        RewardedAd rewardedAd = new RewardedAd(adUnitId);

        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);
        return rewardedAd;
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void checkNetworkConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            buyButton1.GetComponent<Button>().interactable = false;
            buyButton2.GetComponent<Button>().interactable = false;
            buyButton3.GetComponent<Button>().interactable = false;
        }
    }

    public void CoinsAd1000Load()
    {
        if (this.CoinsAd1000.IsLoaded())
        {
            this.CoinsAd1000.Show();
            FindObjectOfType<InGameManager>().AddCoins(1000);
        }
    }

    public void CoinsAd5000Load()
    {
        if (this.CoinsAd5000.IsLoaded())
        {
            this.CoinsAd5000.Show();
            FindObjectOfType<InGameManager>().AddCoins(5000);
        }
    }

    public void CoinsAd10000Load()
    {
        if (this.CoinsAd10000.IsLoaded())
        {
            this.CoinsAd10000.Show();
            FindObjectOfType<InGameManager>().AddCoins(10000);
        }
    }

}
