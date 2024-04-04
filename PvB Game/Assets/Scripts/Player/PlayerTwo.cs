using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : PlayerMovement
{
	// Start is called before the first frame update
	void Start()
	{
		playerIndex = 1;
	}
	public override void Movement()
	{
		base.Movement();
		float speed = Input.GetAxis("_PlayerTwo") * force * 15f;

		Vector3 movement = new(-speed, 0, 0);

		rb.AddForce(speed * Time.deltaTime * movement);
	}
	public override void GatheringMovement()
	{
		base.GatheringMovement();
	}
}
