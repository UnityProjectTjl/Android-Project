using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public Text points;
    public GameObject checkpoint, player;
    public AdManager adManager;
    private int levelId;
    private int coins;

    public float targetTime;

    public InGameManager()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        levelId = PlayerPrefs.GetInt("LevelId");
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
                coins += 1000;

                PlayerPrefs.SetInt("Coins", coins);
            }
            else if (targetTime >= 10.0f)
            {
                coins += 850;

                PlayerPrefs.SetInt("Coins", coins);
            }
            else if (targetTime >= 5.0f)
            {
                coins += 350;

                PlayerPrefs.SetInt("Coins", coins);
            }
            else
            {
                coins += 100;

                PlayerPrefs.SetInt("Coins", coins);
            }

            levelId += 1;

            PlayerPrefs.SetInt("LevelId", levelId);

            adManager.GameOver();
        }
    }
}
