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
    public void UpdateSliderValue(OnStatChangedEventArgs newStat)
    {
		currentSlider.value = newStat.CurrentAsPercentage;
    }
}
