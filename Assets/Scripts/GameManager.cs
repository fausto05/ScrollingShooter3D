using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text killText;
    public GameObject winPanel;
    public GameObject gameOverPanel;
    public int killsToWin = 10;

    private int currentKills = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentKills = 0; 
        UpdateKillUI();

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void AddKill()
    {
        currentKills++;
        UpdateKillUI();

        if (currentKills >= killsToWin)
        {
            WinGame();
        }
    }

    public void UpdateKillUI()
    {
        if (killText != null)
        {
            killText.text = "Kills: " + currentKills;
        }
    }

    void WinGame()
    {
        Time.timeScale = 0f;

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
