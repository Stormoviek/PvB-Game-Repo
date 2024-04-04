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

	// Update is called once per frame
	void Update()
	{
		
	}
	public override void Movement()
	{
		base.Movement();
		float speed = Input.GetAxis("_PlayerTwo") * force * 15f;

		Vector3 movement = new Vector3(-speed, 0, 0);

		rb.AddForce(movement * speed * Time.deltaTime);
	}
}
