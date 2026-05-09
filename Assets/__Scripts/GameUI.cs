using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public static GameUI S;

    [Header("Score")]
    public int score = 0;
    public int highScore = 0;

    [Header("UI Text")]
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public TMP_Text deathText;

    void Awake()
    {
        S = this;

        highScore = PlayerPrefs.GetInt("HighScore", 0);

        UpdateScoreUI();

        if (deathText != null)
        {
            deathText.gameObject.SetActive(false);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void ShowDeathMessage()
    {
        if (deathText != null)
        {
            deathText.text = "You died! Restarting...";
            deathText.gameObject.SetActive(true);
        }
    }
}