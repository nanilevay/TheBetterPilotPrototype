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
    public int a0, a1;

    public LongClickButton button;

    EventSystem eventSystem = EventSystem.current;

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        string log = "Message arrived: " + msg;
        string[] dataArray = msg.Split(' ');
        
        a0 = int.Parse(dataArray[0]);
        a1 = int.Parse(dataArray[1]);

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
        if (a1 == 0)
        {
            button.pointerDown = true;

            ExecuteEvents.Execute(button.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
        }
    }
}
