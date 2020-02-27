using UnityEngine;
using UnityEngine.SceneManagement;

public class btnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached") + 1;

        SceneManager.LoadScene("Level" + levelReached);
    }
}
