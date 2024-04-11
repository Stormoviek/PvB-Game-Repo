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

    // Initialiseer het script en de scores
    public void InitializePlayerScores()
    {
        playerScores.Clear();

        for (int i = 0; i < 4; i++)
        {
            string playerName = "Player" + i;
            playerScores.Add(playerName, 0);
        }
    }

    // Update de score van elke speler op basis van welke plaats ze zijn geindigd
    public void UpdatePlayerScore(string[] playerPlacement)
    {
        playerPlacements = playerPlacement;

        // Loop door elke spelerplaatsing en update hun score
        for (int i = 0; i < playerPlacement.Length; i++)
        {
            string playerName = playerPlacement[i];

            if (playerScores.ContainsKey(playerName))
            {
                int score = 4 - i; // De score wordt bepaald door de plaatsing (1e plaats krijgt 4 punten, 2e 3 punten, etc.)
                playerScores[playerName] += score;
            }

            UpdatePlayerScoreDisplay();
        }
    }

    // Pak de score van een van de spelers
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

    // Update de weergave van de scores
    public void UpdatePlayerScoreDisplay()
    {
        Debug.Log("Updating player score!");

        // Sorteer de spelers op basis van hun scores
        playerScoreDisplays.Sort((a, b) => playerScores[b.playerName].CompareTo(playerScores[a.playerName]));

        foreach (var display in playerScoreDisplays)
        {
            display.score = GetPlayerScore(display.playerName);
        }

        scoreLeaderboard = GameObject.Find("ScoreLeaderboard");

        if (scoreLeaderboard != null)
        {
            TextMeshProUGUI[] texts = scoreLeaderboard.GetComponentsInChildren<TextMeshProUGUI>();

            // ga door alle teksten heen en update de tekst met de speler scores
            for (int i = 0; i < texts.Length && i < playerScoreDisplays.Count; i++)
            {
                Debug.Log("Writing scores!");
                texts[i].text = $"{playerScoreDisplays[i].playerName}: {playerScoreDisplays[i].score}";
            }
        }
    }

    // houd bij hoeveel games er zijn gespeeld
    public void GameCount()
    {
        count++;

        if (count == 3)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
