using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[ExecuteInEditMode]
public class SliderGradient : MonoBehaviour
{
    [SerializeField] private Gradient gradient = null;
    [SerializeField] private Image image = null;
    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.color = gradient.Evaluate(image.fillAmount);
    }
}
