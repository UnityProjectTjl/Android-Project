using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{

    public Sprite[] skins;
    public Color[] colors;
    int ImageIndex = 0;
    public GameObject vorschau;
    SpriteRenderer vorschauSprite;
    public Button nextSkin;
    public Button lastSkin;
    public Button buyButton;
    public Text costText;
    public Text bankText;
    public Text notEnoughText;
    private int coins;
    // Start is called before the first frame update

    void Start()
    {
        vorschauSprite = vorschau.GetComponent<SpriteRenderer>();
        Debug.Log(ImageIndex);
        vorschauSprite.sprite = skins[0];

        notEnoughText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int bank = PlayerPrefs.GetInt("Coins");
        bankText.text = bank.ToString();
    }
    public void ShowNextImage()
    {
        if (this.ImageIndex <= skins.Length)
        {
            //Ersten Skin laden
            this.ImageIndex++;
            vorschauSprite.sprite = skins[this.ImageIndex];

            Debug.Log(this.ImageIndex);
            // vorschauSprite.color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            //Nichts machen oder letzten Sprite anzeigen
        }

        switch (this.ImageIndex)
        {
            case 0:
                costText.text = "0";
                buyButton.GetComponentInChildren<Text>().text = "Wählen";
                break;
            case 1:
                costText.text = "800";
                buyButton.GetComponentInChildren<Text>().text = "Kaufen";
                break;
            case 2:
                costText.text = "1500";
                buyButton.GetComponentInChildren<Text>().text = "Kaufen";
                break;
            case 3:
                costText.text = "3000";
                buyButton.GetComponentInChildren<Text>().text = "Kaufen";
                break;
        }

        notEnoughText.enabled = false;
    }
    public void SchowLastImage()
    {
        Debug.Log(this.ImageIndex);
        
        if (this.ImageIndex > 0)
        {
            this.ImageIndex--;
            vorschauSprite.sprite = skins[this.ImageIndex];

            Debug.Log(this.ImageIndex);
        }
        else
        {
            //Nichts machen oder letzten Sprite anzeigen
       }
        switch (this.ImageIndex)
        {
            case 0:
                costText.text = "0";
                buyButton.GetComponentInChildren<Text>().text = "Wählen";
                break;
            case 1:
                costText.text = "800";
                buyButton.GetComponentInChildren<Text>().text = "Kaufen";
                break;
            case 2:
                costText.text = "1500";
                buyButton.GetComponentInChildren<Text>().text = "Kaufen";
                break;
            case 3:
                costText.text = "3000";
                buyButton.GetComponentInChildren<Text>().text = "Kaufen";
                break;
        }

        notEnoughText.enabled = false;
    }

    public void BuySkin()
    {
        coins = PlayerPrefs.GetInt("Coins");

        switch (this.ImageIndex)
        {
            case 0:
                if (coins >= 800)
                {
                   
                    costText.text = "0";
                    PlayerPrefs.SetInt("Player One", 0);
                }
                else
                {
                    notEnoughText.enabled = true;
                }
                break;
            case 1:
                if (coins >= 800)
                {
                    coins -= 800;
                    PlayerPrefs.SetInt("Coins", coins);

                    costText.text = "800";
                    PlayerPrefs.SetInt("Player One", 1);
                }
                else
                {
                    notEnoughText.enabled = true;
                }
                break;
            case 2:
                if (coins >= 1500)
                {
                    coins -= 1500;
                    PlayerPrefs.SetInt("Coins", coins);

                    costText.text = "1500";
                    PlayerPrefs.SetInt("Player One", 2);
                }
                else
                {
                    notEnoughText.enabled = true;
                }
                break;
            case 3:
                if (coins >= 3000)
                {
                    coins -= 3000;
                    PlayerPrefs.SetInt("Coins", coins);

                    costText.text = "3000";
                    PlayerPrefs.SetInt("Player One", 3);
                }
                else
                {
                    notEnoughText.enabled = true;
                }
                break;
        }
    }
}
