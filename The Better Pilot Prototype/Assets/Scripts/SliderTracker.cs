using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderTracker : MonoBehaviour
{
    public string CurrentVal = "0";

    public TextMeshProUGUI textDisplay;

    public Slider mainSlider;

    public void SubmitSliderSetting()
    {      
        textDisplay.text = Mathf.RoundToInt(mainSlider.value * 100).ToString() + "%";
    }
}