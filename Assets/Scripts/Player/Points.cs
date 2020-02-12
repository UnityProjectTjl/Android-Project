using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text points;
    private int score;
    public GameObject checkpoint, player;
    public AdManager adManager;
    private int levelId;

    public float targetTime = 30.0f;

    public Points()
    {
        levelId = 1;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (targetTime >= 15.0f)
            {
                score = +100;
            } else if (targetTime >= 5.0f)
            {
                score = +50;
            } else
            {
                score++;
            }

            points.text = score.ToString();
            player.transform.position = checkpoint.transform.position;
        }

        if (score == 3)
        {
            levelId++;

            adManager.GameOver(levelId);
        }
    }
}
