/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;



/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class SensorListener : MonoBehaviour
{
    public bool logArrivingMessages = true;
    public int d1, d2, d3, d4, d5, d6, d7;


    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        string log = "Message arrived: " + msg;
        string[] dataArray = msg.Split(' ');
        
        d1 = int.Parse(dataArray[0]);
        d2 = int.Parse(dataArray[1]);

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
}
