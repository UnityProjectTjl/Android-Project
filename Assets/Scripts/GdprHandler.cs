using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GdprHandler : MonoBehaviour
{
    public GameObject GdprConsent;
    private int confirmed;

    public UnityEvent onClick;

    // Start is called before the first frame update
    void Start()
    {
        confirmed = PlayerPrefs.GetInt("confirmed");

        if (confirmed == 0)
        {
            GdprConsent.SetActive(true);
        } else
        {
            GdprConsent.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPrivacyPage()
    {
        Application.OpenURL("https://threeyoungdevs.4lima.de/privacy/index.html");
    }

    public void YesButton()
    {
        PlayerPrefs.SetInt("personalizeAds", 1);
        PlayerPrefs.SetInt("confirmed", 1);

        GdprConsent.SetActive(false);
    }

    public void NoButton()
    {
        PlayerPrefs.SetInt("personalizeAds", 0);
        PlayerPrefs.SetInt("confirmed", 1);

        GdprConsent.SetActive(false);
    }
}
