using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float force = 2;
	public int playerIndex;
	public Rigidbody rb;
	public float horizontal;
	public float vertical;
	public Vector3 playerVelocity;
	//string[] players = { "PlayerOne", "PlayerTwo", "PlayerThree", "PlayerFour" };
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Movement();
		GatheringMovement();
	}

	public virtual void Movement()
	{
		
	}
	public virtual void GatheringMovement()
	{
		if (playerIndex == 0 || playerIndex == 2)
		{
			horizontal = Input.GetAxis("HorizontalOne");
			vertical = Input.GetAxis("VerticalOne");
		}
		if (playerIndex == 1 || playerIndex == 3)
		{
			horizontal = Input.GetAxis("HorizontalTwo");
			vertical = Input.GetAxis("VerticalTwo");
		}


	}
}
