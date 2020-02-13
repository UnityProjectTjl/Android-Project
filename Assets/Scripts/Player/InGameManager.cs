using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public Text points;
    private int score;
    public GameObject checkpoint, player;
    public AdManager adManager;
    private int levelId;

    public float targetTime;

    public InGameManager()
    {

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
                score = +1000;
            }
            else if (targetTime >= 10.0f)
            {
                score = +850;
            }
            else if (targetTime >= 5.0f)
            {
                score = +350;
            }
            else
            {
                score = +100;
            }

            points.text = score.ToString();
            player.transform.position = checkpoint.transform.position;

            levelId++;

            adManager.GameOver(levelId);
        }
    }
}
