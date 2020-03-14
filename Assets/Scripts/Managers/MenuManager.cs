using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private int coins;
    public Button[] button;

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        

        if (PlayerPrefs.GetInt("Level1-Unlock") == 1)
        {
            button[0].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level2-Unlock") == 1)
        {
            button[1].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level3-Unlock") == 1)
        {
            button[2].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level4-Unlock") == 1)
        {
            button[3].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level5-Unlock") == 1)
        {
            button[4].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level6-Unlock") == 1)
        {
            button[5].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level7-Unlock") == 1)
        {
            button[6].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level8-Unlock") == 1)
        {
            button[7].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level9-Unlock") == 1)
        {
            button[8].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level10-Unlock") == 1)
        {
            button[9].interactable = true;
        }
        if (PlayerPrefs.GetInt("Level11-Unlock") == 1)
        {
            button[10].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
