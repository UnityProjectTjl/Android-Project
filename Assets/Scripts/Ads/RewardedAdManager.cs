using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardedAdManager : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
    public Button Ad100Coins;
    private int personalizeAds;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID
                string appId = "ca-app-pub-3484489003477619~5116842889";
        #elif UNITY_IPHONE
                        string appId = "ca-app-pub-3484489003477619~5116842889";
        #else
                        string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        personalizeAds = PlayerPrefs.GetInt("personalizeAds");

        this.RequestRewardBasedVideo();

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;

        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;

        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RequestRewardBasedVideo()
    {
        #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3484489003477619/4579794443";
        #elif UNITY_IPHONE
                            string adUnitId = "ca-app-pub-3484489003477619/4579794443";
        #else
                            string adUnitId = "unexpected_platform";
        #endif

        if (personalizeAds == 1)
        {
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the rewarded video ad with the request.
            this.rewardBasedVideo.LoadAd(request, adUnitId);
        } else
        {
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder()
                .AddExtra("npa", "1")
                .Build();
            // Load the rewarded video ad with the request.
            this.rewardBasedVideo.LoadAd(request, adUnitId);
        }
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Ad100Coins.interactable = true;
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;

        int coins = PlayerPrefs.GetInt("Coins");

        PlayerPrefs.SetInt("Coins", coins + Convert.ToInt32(amount));
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        this.RequestRewardBasedVideo();

        Ad100Coins.interactable = false;
    }

    public void UserOptToWatchAd()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
    }
}
