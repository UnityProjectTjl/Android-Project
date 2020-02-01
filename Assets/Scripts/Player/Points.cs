﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text points;
    private int score = 0;
    public GameObject checkpoint, player;
    public AdManager adManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            score++;
            points.text = "Punkte: " + score;
            player.transform.position = checkpoint.transform.position;
        }

        if (score == 3)
        {
            int levelId = 1;

            levelId++;

            adManager.GameOver(levelId);
        }
    }
}