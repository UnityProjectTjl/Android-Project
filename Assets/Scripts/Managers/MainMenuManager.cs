using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public Text points;
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        points.text = coins.ToString();
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
