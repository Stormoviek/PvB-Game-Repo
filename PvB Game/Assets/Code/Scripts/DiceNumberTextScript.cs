using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceNumberTextScript : MonoBehaviour
{
    TextMeshProUGUI text;
    public static int diceNumber;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = diceNumber.ToString();
    }
}
