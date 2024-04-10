using System.Collections.Generic;
using UnityEngine;

public class MainScoreManager : MonoBehaviour
{
    public Dictionary<string, int> playerScores = new Dictionary<string, int>();
    public string[] playerPlacements;

    [SerializeField]
    private List<PlayerScoreDisplay> playerScoreDisplays = new List<PlayerScoreDisplay>();

    [System.Serializable]
    public class PlayerScoreDisplay
    {
        public string playerName;
        public int score;
    }

    private void InitializePlayerScores()
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

    private void UpdatePlayerScoreDisplay()
    {
        foreach (var display in playerScoreDisplays)
        {
            display.score = GetPlayerScore(display.playerName);
        }
    }
}
