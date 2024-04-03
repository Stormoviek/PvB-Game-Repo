using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovement : MonoBehaviour
{
	public int force = 2;
	//string[] players = { "PlayerOne", "PlayerTwo", "PlayerThree", "PlayerFour" };
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public abstract void Movement();
}
