using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
	public TextMeshProUGUI timerLabel;

	public float timeRemaining = 60f;
	bool timerIsRunning = false;
	public GameObject timeOverPanel;
	// Start is called before the first frame update
	void Start()
	{
		timerIsRunning = true;
	}
	private void Update()
	{
		if (timerIsRunning)
		{
			if (timeRemaining > 0)
			{
				timeRemaining -= Time.deltaTime;
				DisplayTime(timeRemaining);
			}
			else
			{
				Debug.Log("Time has ran out!");
				timeRemaining = 0;
				timerIsRunning = false;
				timeOverPanel.SetActive(true);
				//timeOverLabel.enabled = true;
				DisplayTime(timeRemaining);
			}
		}
	}
	void DisplayTime(float timeToDisplay)
	{
		timeToDisplay += 1;

		float minutes = Mathf.FloorToInt(timeRemaining / 60);
		float seconds = Mathf.FloorToInt(timeRemaining % 60);

		timerLabel.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
