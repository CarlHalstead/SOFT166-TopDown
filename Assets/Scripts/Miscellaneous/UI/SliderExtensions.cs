using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderExtensions : MonoBehaviour
{
    private Slider currentSlider = null;

    private void Awake()
    {
        currentSlider = GetComponent<Slider>();
    }

    /// <summary>
    /// Percentage on a scale of 0 through to 1.
    /// </summary>
    /// <param name="percentage"></param>
    public void UpdateSliderValue(float percentage)
    {
        currentSlider.value = percentage;
    }
}
