using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public Text points;
    public GameObject checkpoint, player;
    private int coins;

    public float targetTime;

    public InGameManager()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        coins = PlayerPrefs.GetInt("Coins");
        points.text = coins.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (targetTime >= 15.0f)
            {
                coins += 500;

                PlayerPrefs.SetInt("Coins", coins);
            }
            else if (targetTime >= 10.0f)
            {
                coins += 250;

                PlayerPrefs.SetInt("Coins", coins);
            }
            else if (targetTime >= 5.0f)
            {
                coins += 100;

                PlayerPrefs.SetInt("Coins", coins);
            }
            else
            {
                coins += 50;

                PlayerPrefs.SetInt("Coins", coins);
            }

            FindObjectOfType<AdManager>().GameOver();
        }
    }

    public void CoinCollected()
    {
        coins += 1;

        PlayerPrefs.SetInt("Coins", coins);
    }

    public void AddCoins(int coins)
    {
        PlayerPrefs.SetInt("Coins", coins);
    }
}
