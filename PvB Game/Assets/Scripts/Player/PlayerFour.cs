using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFour : PlayerMovement
{
	// Start is called before the first frame update
	void Start()
	{
		playerIndex = 3;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	public override void Movement()
	{
		base.Movement();
		float speed = Input.GetAxis("_PlayerFour") * force * 15f;

		Vector3 movement = new Vector3(-speed, 0, 0);

		rb.AddForce(movement * speed * Time.deltaTime);
	}
}
