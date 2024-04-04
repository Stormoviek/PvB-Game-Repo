using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThree : PlayerMovement
{
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
}
