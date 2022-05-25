using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Uduino;

public class ServoArduino : MonoBehaviour
{
    [Range(0, 255)]

    public int servoValue;

    public rotatingArduino rotator;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(11, PinMode.Servo);
    }

    // Update is called once per frame
    void Update()
    {
        servoValue = map(rotator.analogValue, 0, 1023, 0, 255); //rotator.analogValue; 

        UduinoManager.Instance.analogWrite(11, servoValue); 
    }

    public static int map(int value, int leftMin, int leftMax, int rightMin, int rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
