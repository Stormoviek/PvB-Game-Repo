using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ThrowBar : MonoBehaviour
{
	public float speed = 0.5f;
	public float timer = 0f;
	public Slider slider;
	public Slider slider2;

	public static float powerMultiplier;

	public AnimationCurve curve;
	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime * speed;

		float curveValue = Mathf.PingPong(timer, 1);

		slider.value = curveValue;
		slider2.value = curveValue;

		powerMultiplier = curve.Evaluate(curveValue);
	}
}
