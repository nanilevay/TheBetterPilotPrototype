using UnityEngine;
using UnityEngine.UI;

public class PuzzlePiece : MonoBehaviour
{
    public bool active = true;
    public bool solved = false;
    public string name = "";

    public bool start = false;

    //public AudioSource SuccessSound;

    public void ToggleOn()
    {
        if(this.gameObject.tag == "Slider")
            this.GetComponent<Slider>().interactable = true;


        if (this.gameObject.tag == "Button")
            this.GetComponent<Button>().interactable = true;


        if (this.gameObject.tag == "Display")
        {
            
        }


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

        if (this.gameObject.tag == "RotatingDevice")
        {
            GameObject handle = GameObject.FindGameObjectWithTag("RotatingPiece");
            handle.GetComponent<RotateHandle>().active = true;
        }

        active = true;
    }

    public void ToggleOff()
    {
        if (this.gameObject.tag == "Slider")
            this.GetComponent<Slider>().interactable = false;

        if(this.gameObject.tag == "Button")
            this.GetComponent<Button>().interactable = false;

        if (this.gameObject.tag == "Display")
        {
            this.gameObject.transform.Find("Screen").transform.Find("Screen Text").gameObject.active = false;
        }

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

        if (this.gameObject.tag == "RotatingDevice")
        {
            GameObject handle = GameObject.FindGameObjectWithTag("RotatingPiece");
            handle.GetComponent<RotateHandle>().active = false;
        }

            active = false;
    }
}