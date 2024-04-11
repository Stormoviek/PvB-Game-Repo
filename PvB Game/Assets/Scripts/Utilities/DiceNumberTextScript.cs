using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiceNumberTextScript : MonoBehaviour
{
    public static TextMeshProUGUI text;
    public static TextMeshProUGUI playerCountList;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        playerCountList = GetComponent<TextMeshProUGUI>();
    }
}
