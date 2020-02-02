using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{

    public Sprite[] skins;
    public Color[] colors;
    int ImageIndex = 0;
    public GameObject vorschau;
    SpriteRenderer vorschauSprite;
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
        if (ImageIndex > skins.Length)
        {
            //Ersten Skin laden
           
        }
      
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
    }
}
