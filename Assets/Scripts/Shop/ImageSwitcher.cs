using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{

    public Sprite[] skins;
    public Color[] colors;
    int ImageIndex = -1;
    public GameObject vorschau;
    SpriteRenderer vorschauSprite;
    public Button nextSkin;
    public Button lastSkin;
    // Start is called before the first frame update

    void Start()
    {
        vorschauSprite = vorschau.GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowNextImage()
    {
        if (ImageIndex < skins.Length)
        {
            //Ersten Skin laden
           
           
        }

        ImageIndex++;
        vorschauSprite.sprite = skins[ImageIndex];
        Debug.Log(ImageIndex);
       // vorschauSprite.color = new Color(0f, 0f, 0f, 0f);

    }
    public void SchowLastImage()
    {
        if (ImageIndex >= 1)
        {
            //normal ein Bild zurückgehen
           
        }
        else
        {
            //Nichts machen oder letzten Sprite anzeigen
        }
        ImageIndex--;
        vorschauSprite.sprite = skins[ImageIndex];
    }
}
