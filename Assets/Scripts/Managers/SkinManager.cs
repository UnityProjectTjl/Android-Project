using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Sprite[] skins;


    void Start()
    {
        if (PlayerPrefs.GetInt("Player One") == 0)
        {
            player.GetComponent<SpriteRenderer>().sprite = skins[0];
        }
        if (PlayerPrefs.GetInt("Player One") == 1)
        {
            player.GetComponent<SpriteRenderer>().sprite = skins[1];
        }
        if (PlayerPrefs.GetInt("Player One") == 2)
        {
            player.GetComponent<SpriteRenderer>().sprite = skins[2];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
