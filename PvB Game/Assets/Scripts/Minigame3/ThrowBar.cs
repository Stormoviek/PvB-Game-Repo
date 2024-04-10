using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using TMPro;

public class ThrowBar : MonoBehaviour
{
	public float speed = 0.5f;
	public float timer = 0f;
	public Slider slider;
	public Slider slider2;

	public static float powerMultiplier;
	public static TextMeshProUGUI P1;
	public static TextMeshProUGUI P2;
	public static TextMeshProUGUI P3;
	public static TextMeshProUGUI P4;
	public TextMeshProUGUI _P1;
	public TextMeshProUGUI _P2;
	public TextMeshProUGUI _P3;
	public TextMeshProUGUI _P4;

	public AnimationCurve curve;
	private void Start()
	{
		_P1 = P1;
		_P2 = P2;
		_P3 = P3;
		_P4 = P4;
	}
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
