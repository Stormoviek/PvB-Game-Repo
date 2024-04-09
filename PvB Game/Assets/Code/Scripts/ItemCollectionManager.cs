using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class ItemCollectionManager : MonoBehaviour
{
    private Dictionary<string, int> itemsCollectedByPlayer = new Dictionary<string, int>();

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

    private void Start()
    {
        InitializeItemCounts();
    }
}
