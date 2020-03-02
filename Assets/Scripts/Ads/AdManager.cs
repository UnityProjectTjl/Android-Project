using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    private InterstitialAd interstitial;
    public GameObject gameOverUI;
    public Text buttonText;
    private int activeScene;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestInterstitial();

        gameOverUI.SetActive(false);

        activeScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (activeScene > 8)
        {
            buttonText.text = "Zurück zum Menü";
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
                string adUnitId = "ca-app-pub-3484489003477619/1309459813";
        #elif UNITY_IPHONE
                        string adUnitId = "ca-app-pub-3484489003477619/1309459813";
        #else
                        string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);

        int levelPlayed = PlayerPrefs.GetInt("levelPlayed");

        if (levelPlayed != 1)
        {
            PlayerPrefs.SetInt("levelReached", activeScene);
            PlayerPrefs.SetInt("levelPlayed", 1);
        }

        int adActivated = PlayerPrefs.GetInt("adActivated");

        if (adActivated == 1)
        {
            //Load Ad
            if (this.interstitial.IsLoaded())
            {
                this.interstitial.Show();
            }
        }
    }

    public void LoadNextLevel()
    {
        if (activeScene > 8)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene("Level" + activeScene);
        }
    }
}
