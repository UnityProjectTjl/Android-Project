using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlls : MonoBehaviour
{
    Vector2 startPos, endPos, distance;
    public float jumpspeed;
    public float toleranz;
    bool directionChosen;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //  rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //Richtung d. Spielers wechseln

        //Wenn touched:
        if (directionChosen)
        {
            //Start < Ende --> Nach rechts bewegen/swipe nach rechts
            //Distand = EndPos = StartPos
            //EndPos > StartPos
            //Distand = positiv
            if (startPos.x < endPos.x)
            {
                if (distance.x >= toleranz)
                {
                    rb2d.AddForce(new Vector2(jumpspeed, 0), ForceMode2D.Impulse);
                }


            }
            //Start > Ende --> Nach links bewegen/Swipe nach links
            else
                    if (startPos.x > endPos.x)
            {
                if (distance.x <= -toleranz)
                {
                    //nach links bewegen
                    rb2d.AddForce(new Vector2(-jumpspeed, 0), ForceMode2D.Impulse);
                }

            }


            if (startPos.y < endPos.y)
            {
                if (distance.y >= toleranz)
                {
                    //Nach oben bewegen
                    rb2d.AddForce(new Vector2(0, jumpspeed), ForceMode2D.Impulse);
                }

            }
            else
                if (startPos.y > endPos.y)
            {
                if (distance.y <= -toleranz)
                {
                    //Nach unten bewegen
                    rb2d.AddForce(new Vector2(0, -jumpspeed), ForceMode2D.Impulse);
                }

            }
            directionChosen = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        print("Touches: " + Input.touchCount);

        if (Input.touchCount == 3)
        {
            print("Drei Finger touch");
        }

        //Touch Display wird berührt
        if (Input.touchCount > 0)
        {
            //Ja=> Start der Touch Phase
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                // - Start (Spieler legt den Finger auf Display) == Koordinate
                case TouchPhase.Began:
                    //Position d. Fingers abspeichern
                    startPos = touch.position;
                    directionChosen = false;

                    break;

                // - Ende (Spieler entfernt Finger von Display) == Koordinate

                case TouchPhase.Ended:
                    endPos = touch.position;
                    distance = endPos - startPos;
                    Debug.Log("Start: " + startPos + "Ende: " + endPos + " Distanz: " + distance);
                    directionChosen = true;
                    break;

            }




        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
                return;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            FindObjectOfType<InGameManager>().CoinCollected();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<InGameManager>().PlayerKilled();
        }
    }
}
