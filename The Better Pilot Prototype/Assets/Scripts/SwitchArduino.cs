using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Uduino;


public class SwitchArduino : MonoBehaviour
{

    public Toggle toggler;

    EventSystem eventSystem = EventSystem.current;

    public int num;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(num, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        int buttonValue = UduinoManager.Instance.digitalRead(num);

        if (buttonValue == 0)
        {
            //Debug.Log("switch off");
            ButtonReleased();

        }


        if (buttonValue == 1)
        {
            //Debug.Log("switch on");
            ButtonClicked();

        }
    }


    public void ButtonClicked()
    {
        //button.onClick.Invoke();

        toggler.isOn = true;

        //  button.Select();

        //ExecuteEvents.Execute(button.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);

    }


    public void ButtonReleased()
    {
        toggler.isOn = false;

    }
}
