using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRounds : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public GameObject playerThree;
    public GameObject playerFour;
    public List<GameObject> playerBalls;

    public int playerRounds;
    public PlayerOne _playerOne;
    public PlayerTwo _playerTwo;
    public PlayerMovement _playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerRounds = 1;
        RoundStart(playerRounds);
        //_playerOne = GetComponent<PlayerOne>();
        //_playerTwo = GetComponent<PlayerTwo>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_playerOne.objectThrown == true && _playerTwo.objectThrown == true)
        //{
        //    playerRounds = 2;
        //    RoundStart(playerRounds);
        //}
    }
    public void RoundStart(int round)
    {
		if (playerRounds == 1)
		{
            playerOne.SetActive(true);
            playerTwo.SetActive(true);
            playerThree.SetActive(false);
            playerFour.SetActive(false);
            playerBalls[0].SetActive(true);
            playerBalls[1].SetActive(true);
            playerBalls[2].SetActive(false);
            playerBalls[3].SetActive(false);

            //if (_playerOne.objectThrown == true && _playerTwo.objectThrown == true)
            //{
            //    playerRounds++;
            //}
            
		}
		if (playerRounds == 2)
		{
            playerOne.SetActive(false);
            playerTwo.SetActive(false);
            playerThree.SetActive(true);
            playerFour.SetActive(true);
            playerBalls[0].SetActive(false);
            playerBalls[1].SetActive(false);
            playerBalls[2].SetActive(true);
            playerBalls[3].SetActive(true);
		}
	}
}
