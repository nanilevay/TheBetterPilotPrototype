using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HueSlider : MonoBehaviour
{
  
   
    public TextMeshProUGUI textDisplay;
    public float SliderValue;

    public Slider mainSlider;

    // Drag & drop handle
    public Image handle;

    public void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        handle.color = Color.HSVToRGB(mainSlider.value, 1, 1);

        //if (mainSlider.value * 100 == 100 || mainSlider.value * 100 == 0)
        //    Debug.Log("red");

        //if (mainSlider.value * 100 >= 73 && mainSlider.value * 100 <= 82)
        //    Debug.Log("purple");

        //if (mainSlider.value * 100 >= 50 && mainSlider.value * 100 <= 60)
        //    Debug.Log("light blue");

        //if (mainSlider.value * 100 >= 14 && mainSlider.value * 100 <= 34)
        //    Debug.Log("lime");

        //if (mainSlider.value * 100 >= 83 && mainSlider.value * 100 <= 98)
        //    Debug.Log("pink");

     //   Debug.Log(handle.color);
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
