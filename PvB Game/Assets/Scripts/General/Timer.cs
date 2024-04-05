using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
	float timerStart = 0;
	float timerEnd = 60f;
	public TextMeshProUGUI timerLabel;
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(UseTimer(60));
	}
	IEnumerator UseTimer(float timerInSeconds)
	{
		float counter = 0;
		while (counter < timerInSeconds)
		{
			counter += Time.deltaTime;
			timerLabel.text = counter.ToString();
			yield return null;
		}
	}
}
