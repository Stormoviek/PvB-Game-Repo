using System.Collections;
using System.Collections.Generic;
using TMPro;
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
	//bool objectThrown = false;

	GameRounds gameRounds;
	
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		gameRounds = GetComponent<GameRounds>();
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
		
	}
	public void ThrowPlayer(GameObject throwingPlayer, TextMeshProUGUI distanceToObject, bool thrownObject)
	{
		if (thrownObject)
			return;

		if (objectToThrow)
		{
			var otherPlayer = objectToThrow.GetComponent<Rigidbody>();
			otherPlayer.useGravity = true;
			otherPlayer.AddForce(ThrowBar.powerMultiplier * throwForce * -transform.right);
			thrownObject = true;
			StartCoroutine(CalculateDistanceToObject(distanceToObject));
		}
	}
	IEnumerator CalculateDistanceToObject(TextMeshProUGUI objectDistance)
	{
		yield return new WaitForSeconds(2f);
		float distance = Vector3.Distance(objectToThrow.transform.position, transform.position);
		//Debug.Log("Distance to object: " + distance + " meters");
		objectDistance.text = $"{distance} m";
		//if (PlayerOne.objectThrown == true && PlayerTwo.objectThrown == true)
		//{
		//	gameRounds.playerRounds = 2;
		//	gameRounds.RoundStart(gameRounds.playerRounds);
		//}
	}
}
