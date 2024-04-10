using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLeaderboard : MonoBehaviour
{
    void Start()
    {
        MainScoreManager scoreManager = FindObjectOfType<MainScoreManager>();

        scoreManager.UpdatePlayerScoreDisplay();
    }
}
