using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ProximityDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Detecting = "Not Detected";

    public TextMeshProUGUI textDisplay;

    public bool active = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnSensor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OffSensor();
    }

    public void OnSensor()
    {
        if (active)
        {    
           Detecting = "Detected";   
        }

        else
        {
            Detecting = "Sensor OFF";
        }

        textDisplay.text = Detecting;
    }


    public void OffSensor()
    {
        if (active)
        {
            Detecting = "Not Detected";
        }


        else
        {
            Detecting = "Sensor OFF";
           
        }

        textDisplay.text = Detecting;
    }
}