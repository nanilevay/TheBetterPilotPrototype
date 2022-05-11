using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    public bool active = true;

    public void ToggleOn()
    {
        if(this.gameObject.tag == "Slider")
            this.GetComponent<Slider>().interactable = true;
        if (this.gameObject.tag == "Button")
            this.GetComponent<Button>().interactable = true;


        if (this.gameObject.tag == "Sensor")
        {

            GameObject[] sensors = GameObject.FindGameObjectsWithTag("SensorArea");

            foreach (GameObject sensor in sensors)
            {
                sensor.GetComponent<ProximityDetector>().active = true;
            }
        }

        if (this.gameObject.tag == "Switch")
            this.GetComponent<Toggle>().interactable = true;

        active = true;
    }



    public void ToggleOff()
    {
        if (this.gameObject.tag == "Slider")
            this.GetComponent<Slider>().interactable = false;
        if(this.gameObject.tag == "Button")
            this.GetComponent<Button>().interactable = false;


        if (this.gameObject.tag == "Sensor")
        {

            GameObject[] sensors = GameObject.FindGameObjectsWithTag("SensorArea");

            foreach (GameObject sensor in sensors)
            {
                sensor.GetComponent<ProximityDetector>().active = false;
            }
        }


        if (this.gameObject.tag == "Switch")
            this.GetComponent<Toggle>().interactable = false;

        active = false;
    }
}
