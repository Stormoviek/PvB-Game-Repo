using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int[] selectedCharacters;

    private int currentPlayer = 0;
    private int playersSelected = 1;

    public void NextCharacter()
    {
        characters[selectedCharacters[currentPlayer]].SetActive(false);
        selectedCharacters[currentPlayer] = (selectedCharacters[currentPlayer] + 1) % characters.Length;
        characters[selectedCharacters[currentPlayer]].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacters[currentPlayer]].SetActive(false);
        selectedCharacters[currentPlayer]--;
        if (selectedCharacters[currentPlayer] < 0)
        {
            selectedCharacters[currentPlayer] += characters.Length;
        }
        characters[selectedCharacters[currentPlayer]].SetActive(true);
    }

    public void NextPlayer()
    {
        if (playersSelected >= selectedCharacters.Length)
            return;

        characters[selectedCharacters[currentPlayer]].SetActive(false);

        currentPlayer = (currentPlayer + 1) % selectedCharacters.Length;
        playersSelected++;

        selectedCharacters[currentPlayer] = (0);
        characters[selectedCharacters[currentPlayer]].SetActive(true);
    }

    public void StartGame()
    {
        if (playersSelected < selectedCharacters.Length)
        {
            NextPlayer();
            return;
        }
        else
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }

        for (int i = 0; i < selectedCharacters.Length; i++)
        {
            PlayerPrefs.SetInt("selectedCharacter" + i, selectedCharacters[i]);
        }
    }
}
