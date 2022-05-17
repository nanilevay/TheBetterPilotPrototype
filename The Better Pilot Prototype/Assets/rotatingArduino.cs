using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Uduino;

public class rotatingArduino : MonoBehaviour
{

    UduinoManager manager;

    public Slider slider;

    public RotateHandle rotator;

    // Start is called before the first frame update
    void Start()
    {
        manager = UduinoManager.Instance;

        manager.pinMode(AnalogPin.A0, PinMode.Input);
    }

    // Update is called once per frame
    void Update()
    {
        int analogValue = manager.analogRead(AnalogPin.A0);

        slider.value = (float)analogValue / 1000.0f;

        rotator.RotateObject((float)analogValue / 1000.0f);
    }
}
