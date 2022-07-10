using UnityEngine;
using Uduino;

public class ProximityDetectorArduino : MonoBehaviour
{
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