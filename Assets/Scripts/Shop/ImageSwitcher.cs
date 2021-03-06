﻿using System.Collections;
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

    private int buyedSkin1;
    private int buyedSkin2;
    // Start is called before the first frame update

    void Start()
    {
        vorschauSprite = vorschau.GetComponent<SpriteRenderer>();
        Debug.Log(ImageIndex);
        vorschauSprite.sprite = skins[0];

        notEnoughText.enabled = false;

        buyedSkin1 = PlayerPrefs.GetInt("BuyedSkin1");
        buyedSkin2 = PlayerPrefs.GetInt("BuyedSkin2");
    }

    // Update is called once per frame
    void Update()
    {
        int bank = PlayerPrefs.GetInt("Coins");
        bankText.text = bank.ToString();
    }
    public void ShowNextImage()
    {
        if (this.ImageIndex < skins.Length - 1)
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

        PrepareShop(this.ImageIndex);
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

        PrepareShop(this.ImageIndex);
    }

    public void PrepareShop(int imageIndex)
    {
        switch (imageIndex)
        {
            case 0:
                costText.text = "0";
                buyButton.GetComponentInChildren<Text>().text = "Wählen";
                break;
            case 1:
                if (buyedSkin1 == 1)
                {
                    costText.text = "0";
                    buyButton.GetComponentInChildren<Text>().text = "Wählen";
                } else
                {
                    costText.text = "800";
                    buyButton.GetComponentInChildren<Text>().text = "Kaufen";
                }
                break;
            case 2:
                if (buyedSkin2 == 1)
                {
                    costText.text = "0";
                    buyButton.GetComponentInChildren<Text>().text = "Wählen";
                }
                else
                {
                    costText.text = "1500";
                    buyButton.GetComponentInChildren<Text>().text = "Kaufen";
                }
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
                costText.text = "0";
                PlayerPrefs.SetInt("Player One", 0);
                break;
            case 1:
                if (coins >= 800)
                {
                    coins -= 800;
                    PlayerPrefs.SetInt("Coins", coins);
                    PlayerPrefs.SetInt("BuyedSkin1", 1);

                    costText.text = "800";
                    PlayerPrefs.SetInt("Player One", 1);
                }
                else if (buyedSkin1 == 1)
                {
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
                    PlayerPrefs.SetInt("BuyedSkin2", 1);

                    costText.text = "1500";
                    PlayerPrefs.SetInt("Player One", 2);
                }
                else if (buyedSkin2 == 1)
                {
                    PlayerPrefs.SetInt("Player One", 2);
                }
                else
                {
                    notEnoughText.enabled = true;
                }
                break;
        }
    }
}
