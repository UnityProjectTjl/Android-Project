using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUnlockManager : MonoBehaviour
{
    public Button[] button;
    private int coins;
    private int levelBuyed;
    public Text notEnoughText;
    public GameObject panel;
    public GameObject okButton;

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        levelBuyed = PlayerPrefs.GetInt("levelBuyed");

        notEnoughText.enabled = false;
        okButton.SetActive(false); 

        if (PlayerPrefs.GetInt("Level1-Unlock") != 1)
        {
            button[0].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level2-Unlock") != 1)
        {
            button[1].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level3-Unlock") != 1)
        {
            button[2].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level4-Unlock") != 1)
        {
            button[3].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level5-Unlock") != 1)
        {
            button[4].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level6-Unlock") != 1)
        {
            button[5].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level7-Unlock") != 1)
        {
            button[6].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level8-Unlock") != 1)
        {
            button[7].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level9-Unlock") != 1)
        {
            button[8].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level10-Unlock") != 1)
        {
            button[9].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level11-Unlock") != 1)
        {
            button[10].interactable = false;
        }
        if (PlayerPrefs.GetInt("Level12-Unlock") != 1)
        {
            button[11].interactable = false;
        }
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
                    }
                    else
                    {
                        SceneManager.LoadScene("Level" + level);
                    }
                    break;
                case 10:
                    if (levelBuyed != 1)
                    {
                        coins -= 13000;
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
                        coins -= 14000;
                        PlayerPrefs.SetInt("Coins", coins);
                        PlayerPrefs.SetInt("levelBuyed", 1);
                        SceneManager.LoadScene("Level" + level);
                    }
                    else
                    {
                        SceneManager.LoadScene("Level" + level);
                    }
                    break;
                case 12:
                    if (levelBuyed != 1)
                    {
                        coins -= 14000;
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
        }
        else
        {
            notEnoughText.enabled = true;
            panel.SetActive(false);
            okButton.SetActive(true);
        }
    }

    public void OKButtonClicked()
    {
        panel.SetActive(true);
        notEnoughText.enabled = false;
        okButton.SetActive(false);
    }
}
