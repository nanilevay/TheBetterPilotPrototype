using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Uduino;

public class SliderArduino : MonoBehaviour
{
    public Slider slider;

    UduinoManager manager;


    // Start is called before the first frame update
    void Start()
    {
        manager = UduinoManager.Instance;

        manager.pinMode(AnalogPin.A1, PinMode.Input);
    }

    // Update is called once per frame
    void Update()
    {
        int analogValue = manager.analogRead(AnalogPin.A1);

        slider.value = (float)analogValue / 100.0f;
    }
}
