using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ServoRotation : MonoBehaviour
{
    public bool active = true;
    [SerializeField] private Canvas m_Canvas;
    public TextMeshProUGUI textDisplay;

    public float value;
    public float manualvalue;
    public int periodLength; //Seconds
    public float amount; //Amount to add

    public float maxVal;
    public float minVal;

    public bool increasing = true;

    public RotateHandle rotator;

    public Toggle[] toggles;

    public bool valid;


    void Update()
    {
        if (!rotator.IsMoving)
        {
            if (increasing)
            {
                value += amount * Time.deltaTime * periodLength;
            }

            else
            {
                value -= amount * Time.deltaTime * periodLength;
            }

            if (value <= 0)
                increasing = true;

            if (value >= 180)
                increasing = false;

            RotateObject(value);
        }

        else
        {
            if (rotator.SendValue)
            {
                manualvalue += 1;
            }

            if (value >= 90 && manualvalue >= 90 && toggles[0].isOn && !toggles[1].isOn)
            {
                valid = true;
            }

            if (value < 90 && manualvalue < 90 && toggles[1].isOn && !toggles[0].isOn)
            {
                valid = true;
            }

            if (valid)
            {
                RotateObject(manualvalue);
            }
        }

        

        textDisplay.text = Mathf.Round(value).ToString();

    }
    public void RotateObject(float valueToRotate)
    {
        // gameObject.transform.localRotation = Quaternion.Euler(0, 0, valueToRotate);

        transform.rotation = Quaternion.Euler(0, 0, valueToRotate);
        
        if(rotator.IsMoving)
            value = manualvalue;
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
