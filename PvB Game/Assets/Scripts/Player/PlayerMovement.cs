using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float force = 2;
	public float jumpForce = 5f;

	public int playerIndex;
	public Rigidbody rb;

	public Vector3 playerVelocity;

	public GameObject objectToThrow;
	public float throwForce = 500f;
	bool objectThrown = false;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
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
			if (Input.GetKeyDown(KeyCode.W))
			{
				transform.position += jumpForce * Time.deltaTime * Vector3.up;
			}
			if (Input.GetKeyDown(KeyCode.S))
			{
				transform.position += force * Time.deltaTime * Vector3.down;
			}
			if (Input.GetKeyDown(KeyCode.A))
			{
				transform.position += force * Time.deltaTime * Vector3.right;
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				transform.position += force * Time.deltaTime * Vector3.left;
			}
		}
		if (playerIndex == 1 || playerIndex == 3)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				transform.position += jumpForce * Time.deltaTime * Vector3.up;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				transform.position += force * Time.deltaTime * Vector3.down;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				transform.position += force * Time.deltaTime * Vector3.right;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				transform.position += force * Time.deltaTime * Vector3.left;
			}
		}
	}
	public virtual void ThrowingGame()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			ThrowPlayer(objectToThrow);
		}
		if (Input.GetKeyDown(KeyCode.J))
		{
			ThrowPlayer(objectToThrow);
		}
	}
	public void ThrowPlayer(GameObject throwingPlayer)
	{
		if (objectThrown)
			return;

		if (objectToThrow)
		{
			var otherPlayer = objectToThrow.GetComponent<Rigidbody>();
			otherPlayer.AddForce(ThrowBar.powerMultiplier * throwForce * transform.forward);
			objectThrown = true;
			StartCoroutine(CalculateDistanceToObject());
		}
	}
	IEnumerator CalculateDistanceToObject()
	{
		yield return new WaitForSeconds(2f);
		float distance = Vector3.Distance(objectToThrow.transform.position, transform.position);
		Debug.Log("Distance to object: " + distance + " meters");
	}
}
