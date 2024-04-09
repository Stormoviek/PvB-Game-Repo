using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerThree : PlayerMovement
{
	public TextMeshProUGUI distanceThrown;
	public bool objectThrown = false;
	// Start is called before the first frame update
	void Start()
	{
		playerIndex = 2;
	}
	public override void Movement()
	{
		base.Movement();
		float speed = Input.GetAxis("_PlayerThree") * force * 15f;

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
			ThrowPlayer(objectToThrow, distanceThrown, objectThrown);
		}
	}
}
