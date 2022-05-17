using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class test : MonoBehaviour
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
        //Debug.Log(distance);
        if (distance > 100)
            panel.SetActive(true);
        else
            panel.SetActive(false);

    }

    void DataReceived(string data, UduinoDevice baord)
    {
        bool ok = float.TryParse(data, out distance);
    }
}
