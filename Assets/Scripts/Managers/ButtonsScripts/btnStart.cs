using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnStart : MonoBehaviour
{
    private int levelReached;
    public Text playButtonText;

    // Start is called before the first frame update
    void Start()
    {
        levelReached = PlayerPrefs.GetInt("levelReached") + 1;

        if (levelReached > 1)
        {
            playButtonText.text = "Level fortsetzen";
        } else
        {
            playButtonText.text = "Start";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    { 
        SceneManager.LoadScene("Level" + levelReached);
    }
}
