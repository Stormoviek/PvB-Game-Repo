using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainScoreManager : MonoBehaviour
{
    public Dictionary<string, int> playerScores = new Dictionary<string, int>();
    public string[] playerPlacements;

    [SerializeField]
    private List<PlayerScoreDisplay> playerScoreDisplays = new List<PlayerScoreDisplay>();

    [SerializeField]
    private GameObject scoreLeaderboard;

    [System.Serializable]
    public class PlayerScoreDisplay
    {
        public string playerName;
        public int score;
    }

    public int count = 0;

    public void InitializePlayerScores()
    {
        playerScores.Clear();

        for (int i = 0; i < 4; i++)
        {
            string playerName = "Player" + i;
            playerScores.Add(playerName, 0);
        }
    }

    public void UpdatePlayerScore(string[] playerPlacement)
    {
        playerPlacements = playerPlacement;

        for (int i = 0; i < playerPlacement.Length; i++)
        {
            string playerName = playerPlacement[i];

            if (playerScores.ContainsKey(playerName))
            {
                int score = 4 - i;
                playerScores[playerName] += score;
            }

            UpdatePlayerScoreDisplay();
        }
    }

    public int GetPlayerScore(string playerName)
    {
        if (playerScores.ContainsKey(playerName))
        {
            return playerScores[playerName];
        }
        else
        {
            return 0;
        }
    }

    void Start()
    {
        InitializePlayerScores();
    }

    public void UpdatePlayerScoreDisplay()
    {
        Debug.Log("Updating player score!");
        playerScoreDisplays.Sort((a, b) => playerScores[b.playerName].CompareTo(playerScores[a.playerName]));

        foreach (var display in playerScoreDisplays)
        {
            display.score = GetPlayerScore(display.playerName);
        }

        scoreLeaderboard = GameObject.Find("ScoreLeaderboard");

        if (scoreLeaderboard != null)
        {
            TextMeshProUGUI[] texts = scoreLeaderboard.GetComponentsInChildren<TextMeshProUGUI>();

            for (int i = 0; i < texts.Length && i < playerScoreDisplays.Count; i++)
            {
                Debug.Log("Writing scores!");
                texts[i].text = $"{playerScoreDisplays[i].playerName}: {playerScoreDisplays[i].score}";
            }
        }
    }

    public void GameCount()
    {
        if (count == 3)
        {
            SceneManager.LoadScene(6);
        }
        else ()
        {
            SceneManager.LoadScene(2);
        }
    }
}
