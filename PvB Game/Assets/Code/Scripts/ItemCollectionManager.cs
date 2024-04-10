using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class ItemCollectionManager : MonoBehaviour
{
    private Dictionary<string, int> itemsCollectedByPlayer = new Dictionary<string, int>();
    private MainScoreManager scoreManager;
    private int countdownTime = 19;

    private void InitializeItemCounts()
    {
        itemsCollectedByPlayer.Clear();

        for (int i = 0; i < 4; i++)
        {
            string playerName = "Player" + i;
            itemsCollectedByPlayer.Add(playerName, 0);
        }
    }

    public void CollectItem(string playerName)
    {
        if (itemsCollectedByPlayer.ContainsKey(playerName))
        {
            itemsCollectedByPlayer[playerName]++;
            Debug.Log(playerName + " collected an item. Total items collected: " + itemsCollectedByPlayer[playerName]);
        }
        else
        {
            return;
        }
    }

    public int GetItemCount(string playerName)
    {
        if (itemsCollectedByPlayer.ContainsKey(playerName))
        {
            return itemsCollectedByPlayer[playerName];
        }
        else
        {
            return 0;
        }
    }

    public void EndGame(string[] playerPlacement)
    {
        scoreManager = FindObjectOfType<MainScoreManager>();


        if (scoreManager != null)
        {
            scoreManager.UpdatePlayerScore(playerPlacement);
        }
        else
        {
            Debug.LogError("MainScoreManager not found!");
        }
    }

    private void Start()
    {
        InitializeItemCounts();
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(1f);
            countdownTime--;
            Debug.Log("Time left: " + countdownTime);
        }

        List<string> playerNames = new List<string>(itemsCollectedByPlayer.Keys);
        playerNames.Sort((a, b) => GetItemCount(b).CompareTo(GetItemCount(a)));

        string[] playerPlacement = playerNames.ToArray();

        EndGame(playerPlacement);
    }

}
