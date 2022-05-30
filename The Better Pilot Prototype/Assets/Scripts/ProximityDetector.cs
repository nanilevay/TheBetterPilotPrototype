using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ProximityDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Detecting = "Not Detected";

    public TextMeshProUGUI textDisplay;

    public bool active = true;

    public bool ProximityDetected = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnSensor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OffSensor();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Detecting == "Detected")
        {
            ProximityDetected = true;
            Detecting = "Detected";
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Detecting = "Not Detected";
            ProximityDetected = false;
        }
    }

    public void OnSensor()
    {
        if (active)
        {    
           Detecting = "Detected";
            ProximityDetected = true;
        }

        else
        {
            Detecting = "Sensor OFF";
            ProximityDetected = false;
        }

        textDisplay.text = Detecting;

     


    }


    public void OffSensor()
    {
        if (active && !Input.GetKey(KeyCode.LeftControl))
        {
                Detecting = "Not Detected";
                ProximityDetected = false;

                textDisplay.text = Detecting;
        }


        else if(!active)
        {
            Detecting = "Sensor OFF";

            textDisplay.text = Detecting;

        }

        
    }
}