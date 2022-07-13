using UnityEngine;
using UnityEngine.UI;

public class ToggleControl : MonoBehaviour
{
    public GameObject ToggleOffImg;

    public SensorListener ToggleObj;

    public int ID = 0;
    public void ToggleOnOff()
    {

        if (this.GetComponent<Toggle>().isOn)
            ToggleOffImg.SetActive(false);

        else
            ToggleOffImg.SetActive(true);
    }

    void Update()
    {
        if (ToggleObj.toggle1 == 0 && ID == 0)
        {
            this.GetComponent<Toggle>().isOn = true;
        }

        if (ToggleObj.toggle1 == 1 && ID == 0)
        {
            this.GetComponent<Toggle>().isOn = false;
        }

        if (ToggleObj.toggle2 == 0 && ID == 1)
        {
            this.GetComponent<Toggle>().isOn = true;
        }

        if (ToggleObj.toggle2 == 1 && ID == 1)
        {
            this.GetComponent<Toggle>().isOn = false;
        }
    }
}