using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Card : MonoBehaviour
{
    private bool isPulled = false;

    void OnMouseDown()
    {
        if (!isPulled)
        {
            int randomIndex = Random.Range(2, 5);
            string sceneToLoad = "Test" + randomIndex;
            SceneManager.LoadScene(sceneToLoad);
            isPulled = true;
            Debug.Log("Card pulled!");
        }
    }
}