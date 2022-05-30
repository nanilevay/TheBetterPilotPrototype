using System;
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

    public int analogValue;

    // Start is called before the first frame update
    void Start()
    {
        //manager = UduinoManager.Instance;

       // manager.pinMode(AnalogPin.A0, PinMode.Input);

       UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    // Update is called once per frame
    void Update()
    {
        // analogValue = manager.analogRead(AnalogPin.A0);

        // slider.value = (float)analogValue / 1000.0f;

        //rotator.RotateObject((float)data / 1000.0f);
    }

    void DataReceived(string data, UduinoDevice board)
    {
        //Debug.Log(data);

        float f = float.Parse(data);


        rotator.RotateObject(f / 1000.0f);
    }
}
