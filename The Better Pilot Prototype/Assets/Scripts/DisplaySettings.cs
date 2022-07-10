using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySettings : MonoBehaviour
{
    public SettingsControl SettingsValues;

    public int SliderVal;
    
    public ButtonPresser Button1, Button2;

    public int Counter = 0;

    // Update is called once per frame
    void Update()
    {
        if(Counter < 0)
        {
            Counter = 0;
        }

        if (Counter > 6)
        {
            Counter = 6;
        }

        //if(Button1.Pressed)
        //{
        //    StartCoroutine(ButtonClicker(0));
        //}

        //if (Button2.Pressed)
        //{
        //    StartCoroutine(ButtonClicker(1));
        //}

        //if (Button1.Pressed)
        //{
        //    StopCoroutine(ButtonClicker(0));
        //}

        //if (Button2.Pressed)
        //{
        //    StopCoroutine(ButtonClicker(1));
        //}

        if (SettingsValues.IsOn)
        {
            SettingsValues.CodeSpeed.value = map(SliderVal, 0, 1023, 10, 30);
        }

        if(Counter == 1)
        {
            SettingsValues.IsOn = true;
        }

        else
        {
            SettingsValues.IsOn = false;
        }
    }

    public IEnumerator ButtonClicker(int bttn)
    {
        if(bttn == 0)
        {
            Button1.Pressed = false;
            Counter--;
        }

        if(bttn == 1)
        {
            Button2.Pressed = false;
            Counter++;
        }

         yield break;
    } 

    public static int map(int value, int leftMin, int leftMax, int rightMin, int rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}