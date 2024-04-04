using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float force = 2;
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
}
