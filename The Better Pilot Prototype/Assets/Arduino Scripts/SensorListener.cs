/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;





/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SensorListener : MonoBehaviour
{
    public bool logArrivingMessages = true;
    public int d0, d1, d2, d3, sliderVal, distanceVal;

    public LongClickButton button;

    public Slider sldr;

    EventSystem eventSystem = EventSystem.current;

    public DisplaySettings settings;

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        string log = "Message arrived: " + msg;
        string[] dataArray = msg.Split(' ');
        
        d0 = int.Parse(dataArray[0]); // rotator button
        d1 = int.Parse(dataArray[1]); // rotator encoder
        d2 = int.Parse(dataArray[2]); // button 1
        d3 = int.Parse(dataArray[3]); // button 2
        sliderVal = int.Parse(dataArray[4]);
        distanceVal = int.Parse(dataArray[5]);

        if (logArrivingMessages)
            Debug.Log(log);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }

    void Update()
    {
        sldr.value = map(sliderVal,0, 1023, 0, 1);

        settings.SliderVal = sliderVal;
        //settings.Button1.Value = d2;
        //settings.Button2.Value = d3;
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}