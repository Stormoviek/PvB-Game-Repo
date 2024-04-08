using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerOne : PlayerMovement
{
	// Start is called before the first frame update
	void Start()
	{
		playerIndex = 0;
	}
	public override void Movement()
	{
		base.Movement();
		float speed = Input.GetAxis("_PlayerOne") * force * 15f;
		//Debug.Log("Speed is: " + speed);

		Vector3 movement = new(-speed, 0, 0);

		rb.AddForce(speed * Time.deltaTime * movement);
	}
	public override void GatheringMovement()
	{
		base.GatheringMovement();
	}
	public override void ThrowingGame()
	{
		base.ThrowingGame();
		if (Input.GetKeyDown(KeyCode.F))
		{
			ThrowPlayer(objectToThrow);
		}
	}
}
