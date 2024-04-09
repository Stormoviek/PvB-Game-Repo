using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Card : MonoBehaviour
{
    private bool isPulled = false;

    public void CardSceneSwitch()
    {
        if (!isPulled)
        {
            int randomIndex = Random.Range(1, 1);
            string sceneToLoad = "Minigame" + randomIndex;
            SceneManager.LoadScene(sceneToLoad);
            isPulled = true;
            Debug.Log("Card pulled!");
        }
    }
}