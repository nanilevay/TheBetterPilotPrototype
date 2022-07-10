using UnityEngine;
using UnityEngine.UI;

public class ToggleControl : MonoBehaviour
{
    public GameObject ToggleOffImg;
    public void ToggleOnOff()
    {
        if(this.GetComponent<Toggle>().isOn)
            ToggleOffImg.SetActive(false);

        else
            ToggleOffImg.SetActive(true);
    }
}