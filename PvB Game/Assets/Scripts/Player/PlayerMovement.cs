using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float force = 2;
	public float jumpForce = 5f;
	public int playerIndex;
	public Rigidbody rb;
	public float horizontal;
	public float vertical;
	public Vector3 playerVelocity;
	public GameObject playerToThrow;
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
		ThrowingGame();
	}

	public virtual void Movement()
	{
		
	}
	public virtual void GatheringMovement()
	{
		if (playerIndex == 0 || playerIndex == 2)
		{
			//horizontal = Input.GetAxis("HorizontalOne");
			//vertical = Input.GetAxis("VerticalOne");

			if (Input.GetKey(KeyCode.W))
			{
				transform.position += jumpForce * Time.deltaTime * Vector3.up;
			}
			if (Input.GetKey(KeyCode.S))
			{
				transform.position += force * Time.deltaTime * Vector3.down;
			}
			if (Input.GetKey(KeyCode.A))
			{
				transform.position += force * Time.deltaTime * Vector3.right;
			}
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += force * Time.deltaTime * Vector3.left;
			}
		}
		if (playerIndex == 1 || playerIndex == 3)
		{
			//horizontal = Input.GetAxis("HorizontalTwo");
			//vertical = Input.GetAxis("VerticalTwo");

			if (Input.GetKey(KeyCode.UpArrow))
			{
				transform.position += jumpForce * Time.deltaTime * Vector3.up;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.position += force * Time.deltaTime * Vector3.down;
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.position += force * Time.deltaTime * Vector3.right;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.position += force * Time.deltaTime * Vector3.left;
			}
		}

		//playerVelocity = new(horizontal, 0, vertical);
		//playerVelocity = playerVelocity.normalized * force * Time.deltaTime;
		//rb.MovePosition(rb.transform.position + playerVelocity);
	}
	public void ThrowingGame()
	{
		if (Input.GetKey(KeyCode.F))
		{
			Debug.Log("Throwing a player!!");
			ThrowPlayer(playerToThrow);
		}
		if (Input.GetKey(KeyCode.J))
		{
			Debug.Log("Throwing a player!!!!!!");
			ThrowPlayer(playerToThrow);
		}
	}
	public void ThrowPlayer(GameObject throwingPlayer)
	{
		Debug.Log("The player has been thrown!!");
	}
}
