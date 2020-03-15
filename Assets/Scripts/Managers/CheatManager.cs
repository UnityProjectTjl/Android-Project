using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheatManager : MonoBehaviour
{
    public GameObject m_player;
    private Rigidbody2D m_rigidbody;
    private ParticleSystem m_particle_system;
    public Text m_coinsText, m_gravityText, m_killEnemiesText, m_particleSystemText;

    void Start()
    {
        m_rigidbody = m_player.GetComponent<Rigidbody2D>();
        m_particle_system = m_player.GetComponent<ParticleSystem>();
        m_particle_system.gameObject.SetActive(false);
        m_coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GravitySwitch()
    {
        if (m_rigidbody.gravityScale == .5)
        {
            m_rigidbody.gravityScale = 0;
            m_gravityText.text = "Schwerkraft: Aus";

        }
        else
        {
            m_rigidbody.gravityScale = .5f;
            m_gravityText.text = "Schwerkraft: An";
        }
    }

    public void addCoins()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("Coins", coins + 5000);
        m_coinsText.text = "Coins: " + PlayerPrefs.GetInt("Coins");
        
    }

    public void ParticleSystemSwitch()
    {
        if (m_particle_system.gameObject.activeSelf)
        {
            m_particle_system.gameObject.SetActive(false);
            m_particleSystemText.text = "Partikel um Spieler: Aus";
        }
        else
        {
            m_particle_system.gameObject.SetActive(true);
            m_particleSystemText.text = "Partikel um Spieler: An";
        }
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
