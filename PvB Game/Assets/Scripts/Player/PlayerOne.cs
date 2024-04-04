using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : PlayerMovement
{
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	public override void Movement()
	{
		base.Movement();
		float speed = Input.GetAxis("_PlayerOne") * force * 15f;
		//Debug.Log("Speed is: " + speed);

		Vector3 movement = new Vector3(-speed, 0, 0);

		rb.AddForce(movement * speed * Time.deltaTime);
	}
}
