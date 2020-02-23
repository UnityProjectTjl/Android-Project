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
    public Text costText;
    // Start is called before the first frame update

    void Start()
    {
        vorschauSprite = vorschau.GetComponent<SpriteRenderer>();
        Debug.Log(ImageIndex);
        vorschauSprite.sprite = skins[0];
       
    }

    // Update is called once per frame
    void Update()
    {
        
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
                costText.text = "800";
                break;
            case 1:
                costText.text = "1500";
                break;
            case 2:
                costText.text = "3000";
                break;
        }

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
                costText.text = "800";
                break;
            case 1:
                costText.text = "1500";
                break;
            case 2:
                costText.text = "3000";
                break;
        }
    }
}
