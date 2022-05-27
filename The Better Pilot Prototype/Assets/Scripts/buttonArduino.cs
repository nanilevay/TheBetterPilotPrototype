using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Uduino;


public class buttonArduino : MonoBehaviour
{

    public Button button;

    EventSystem eventSystem = EventSystem.current;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(2, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        int buttonValue = UduinoManager.Instance.digitalRead(2);

        if(buttonValue == 0)
        {
            ButtonClicked();
        }


        if (buttonValue == 1)
        {
            // Debug.Log("oof");
            ButtonReleased();

        }
    }


    public void ButtonClicked()
    {
        //button.onClick.Invoke();

        ExecuteEvents.Execute(button.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);

        //  button.Select();

        //ExecuteEvents.Execute(button.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);

    }


    public void ButtonReleased()
    {
      
    }
}
