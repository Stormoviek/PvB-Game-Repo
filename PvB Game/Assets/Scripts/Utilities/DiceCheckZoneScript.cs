using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
    public static Dictionary<string, int> playerRolls = new Dictionary<string, int>();
    public int rollCount = 0;

    DiceScript diceScript;

    Vector3 diceVelocity;

    void Awake()
    {
        diceScript = FindObjectOfType<DiceScript>();
    }

    void FixedUpdate()
    {
        diceVelocity = DiceScript.diceVelocity;
    }

    IEnumerator DisplayRollResult(string playerName)
    {
        DiceNumberTextScript.text.text = playerName + " rolled " + playerRolls[playerName].ToString();
        yield return new WaitForSeconds(2f);

        if (rollCount == 4)
        {
            string highestPlayer = "";
            int highestRoll = 0;
            foreach (var entry in playerRolls)
            {
                if (entry.Value > highestRoll)
                {
                    highestRoll = entry.Value;
                    highestPlayer = entry.Key;
                }
            }

            DiceNumberTextScript.text.text = highestPlayer + " had the highest roll with " + highestRoll;
            yield return new WaitForSeconds(2f);
            DiceNumberTextScript.text.text = "";
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (!diceScript.rollsDone && diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            if (rollCount < 4)
            {
                diceScript.rollsDone = true;
                rollCount++;

                string playerName = "Player" + rollCount;

                switch (col.gameObject.name)
                {
                    case "Side1":
                        playerRolls[playerName] = 6;
                        break;
                    case "Side2":
                        playerRolls[playerName] = 5;
                        break;
                    case "Side3":
                        playerRolls[playerName] = 4;
                        break;
                    case "Side4":
                        playerRolls[playerName] = 3;
                        break;
                    case "Side5":
                        playerRolls[playerName] = 2;
                        break;
                    case "Side6":
                        playerRolls[playerName] = 1;
                        break;
                }

                StartCoroutine(DisplayRollResult(playerName));
            }
        }
    }
}
