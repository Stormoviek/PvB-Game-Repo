using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highScoreText;
    public TMPro.TMP_InputField playerNameInput;

    private int score = 0;
    private int highScore = 0;
    private string playerName = "Blank";

    private const string HIGH_SCORE_KEY = "HighScore";
    private const string PLAYER_NAME_KEY = "PlayerName";

    void Start()
    {
        LoadHighScore();
        UpdateHighScoreUI();
        UpdateScoreUI();
    }

    void Update()
    {
        // Test
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseScore(10);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveHighScore();
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateHighScoreUI()
    {
        highScoreText.text = "High Score: " + highScore.ToString() + " (" + playerName + ")";
    }

    void LoadHighScore()
    {
        //highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        //playerName = PlayerPrefs.GetString(PLAYER_NAME_KEY, "Blank");
        highScore = 0;
        playerName = "";
    }

    public void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            playerName = playerNameInput.text;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.SetString(PLAYER_NAME_KEY, playerName);
            PlayerPrefs.Save();
            UpdateHighScoreUI();
        }
    }
}
