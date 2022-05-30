using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class ProximityDetectorArduinoo : MonoBehaviour
{
    public Transform distancePlane;
    float distance = 0;
    public GameObject panel;

    void Start()
    {
        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    void Update()
    {
       // Debug.Log(distance);
        if (distance > 260)
            panel.SetActive(true);
        else
            panel.SetActive(false);

        Debug.Log(distance);

    }

    void DataReceived(string data, UduinoDevice board)
    {
        bool ok = float.TryParse(data, out distance);

      //  Debug.Log(data);
    }
}
