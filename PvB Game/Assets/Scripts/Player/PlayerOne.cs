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
		float speed = Input.GetAxis("_PlayerOne") * force;
	}
}
