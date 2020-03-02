using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUnlockManager : MonoBehaviour
{
    public Button[] levelButtons;
    private int coins;
    private int levelBuyed;
    public Text notEnoughText;

    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        coins = PlayerPrefs.GetInt("Coins");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)

            levelButtons[i].interactable = false;
        }

        levelBuyed = PlayerPrefs.GetInt("levelBuyed");

        notEnoughText.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void buyLevel(int level)
    {
        if (coins >= 12000)
        {
            switch (level)
            {
                case 9:
                    if (levelBuyed != 1)
                    {
                        coins -= 12000;
                        PlayerPrefs.SetInt("Coins", coins);
                        PlayerPrefs.SetInt("levelBuyed", 1);
                        SceneManager.LoadScene("Level" + level);
                    } else
                    {
                        SceneManager.LoadScene("Level" + level);
                    }
                    break;
                case 10:
                    if (levelBuyed != 1)
                    {
                        coins -= 15000;
                        PlayerPrefs.SetInt("Coins", coins);
                        PlayerPrefs.SetInt("levelBuyed", 1);
                        SceneManager.LoadScene("Level" + level);
                    }
                    else
                    {
                        SceneManager.LoadScene("Level" + level);
                    }
                    break;
                case 11:
                    if (levelBuyed != 1)
                    {
                        coins -= 18000;
                        PlayerPrefs.SetInt("Coins", coins);
                        PlayerPrefs.SetInt("levelBuyed", 1);
                        SceneManager.LoadScene("Level" + level);
                    }
                    else
                    {
                        SceneManager.LoadScene("Level" + level);
                    }
                    break;
            }
        } else
        {
            notEnoughText.enabled = true;
        }
    }
}
