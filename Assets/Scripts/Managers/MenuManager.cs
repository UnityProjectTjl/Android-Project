using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void UnlockLevelWithCoins(int cost)
    {
        coins -= cost;

        PlayerPrefs.SetInt("Coins", coins);
    }
}
