using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Finish : MonoBehaviour
{
    public MainScoreManager scoreManager;
    public List<PlayerMovement> players;
    public List<TextMeshProUGUI> playerLabels;

    int count;

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player != null && !players.Contains(player))
        {
            players.Add(player);
            UpdateScoreboard();
        }
    }

    void UpdateScoreboard()
    {
        count++;

        players.Sort((a, b) => players.IndexOf(a).CompareTo(players.IndexOf(b)));

        List<string> sortedPlayerPlacements = new List<string>();

        foreach (var player in players)
        {
            sortedPlayerPlacements.Add("Player" + player.playerIndex);
        }

        if (count == 4)
        {
            count = 0;

            MainScoreManager scoreManager = FindObjectOfType<MainScoreManager>();
            scoreManager.UpdatePlayerScore(sortedPlayerPlacements.ToArray());
        }
        
        for (int i = 0; i < playerLabels.Count && i < sortedPlayerPlacements.Count; i++)
        {
            playerLabels[i].text = sortedPlayerPlacements[i];
        }
    }
}
