using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float force = 2;
	public int playerIndex;
	public Rigidbody rb;
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
	}

	public virtual void Movement()
	{
		
	}
	public void GatheringMovement()
	{
		if (playerIndex == 0 || playerIndex == 2)
		{
			float horizontal = Input.GetAxis("HorizontalOne");
			float vertical = Input.GetAxis("VerticalOne");
		}
		if (playerIndex == 1 || playerIndex == 3)
		{
			float horizontal = Input.GetAxis("HorizontalTwo");
			float vertical = Input.GetAxis("VerticalTwo");
		}
	}
}
