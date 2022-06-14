using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SliderArduino : MonoBehaviour
{
    public Slider slider;

    public SensorListener Sensor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //int analogValue = manager.analogRead(AnalogPin.A1);

        // slider.value = map(((float)Sensor.a1), 0, 1023, 0, 1);
    }


    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
