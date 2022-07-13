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
    public int redMorse, blckMorse, clkEncoder, /*dtEncoder,*/ swEncoder, greenButton,
        blckButton, yellowButton, redButton, blueButton, rotation, toggle1, toggle2, sensor,
        sliderVal;

    public string dtEncoder;

    public LongClickButton button;

    public Slider sldr;

    EventSystem eventSystem = EventSystem.current;

    public DisplaySettings settings;

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        string log = "Message arrived: " + msg;
        string[] dataArray = msg.Split(' ');
        
        redMorse = int.Parse(dataArray[0]); // red morse button
        blckMorse = int.Parse(dataArray[1]); // black morse button
        clkEncoder = int.Parse(dataArray[2]); // clk encoder
        dtEncoder = /*int.Parse(*/dataArray[3]/*)*/; // dtw encoder (button)
       
        swEncoder = int.Parse(dataArray[4]); // dtw encoder (button)


        greenButton = int.Parse(dataArray[5]); // green button
        blckButton = int.Parse(dataArray[6]); // black button
        yellowButton = int.Parse(dataArray[7]); // yellow button
        redButton = int.Parse(dataArray[8]); // red button

        blueButton = int.Parse(dataArray[9]); // blue button
        rotation = int.Parse(dataArray[10]); // rotator value
        toggle1 = int.Parse(dataArray[11]); // toggle 1
        toggle2 = int.Parse(dataArray[12]); // toggle 2
        sliderVal = int.Parse(dataArray[13]); // slider

        sensor = int.Parse(dataArray[14]); // distance sensor  

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
        // fix value 1023
        sldr.value = map(sliderVal,0, 664, 0, 1);

        settings.SliderVal = sliderVal;
        //settings.Button1.Value = d2;
        //settings.Button2.Value = d3;
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}