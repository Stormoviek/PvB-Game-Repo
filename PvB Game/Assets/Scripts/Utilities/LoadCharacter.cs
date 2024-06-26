using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections.Specialized;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform[] spawnPoints;

    public bool changeScale = false;

    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter" + i);
            GameObject prefab = characterPrefabs[selectedCharacter];
            GameObject clone = Instantiate(prefab, spawnPoints[i].position, Quaternion.identity);

            clone.name = "player" + i;
            clone.transform.parent = spawnPoints[i];

            clone.transform.localRotation = Quaternion.Euler(0, 0, 0);

            if (changeScale == true)
            {
                clone.transform.localScale += new Vector3(-0.5f, -0.5f, -0.5f);
            }
        }
    }
}
