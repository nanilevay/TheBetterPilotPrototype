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

    public bool oneCheck;

    public bool longPress;

    public int num;

    public LongClickButton LongClick;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(num, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        int buttonValue = UduinoManager.Instance.digitalRead(num);

        if(buttonValue == 0)
        {  
            ButtonClicked();
            //Debug.Log("oof");
            LongClick.pointerDown = true;
        }

        if (buttonValue == 1)
        {         
            ButtonReleased();
            LongClick.Reset();
            longPress = false;
            oneCheck = true;
        }
    }


    public void ButtonClicked()
    {
        //button.onClick.Invoke();

        ExecuteEvents.Execute(button.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);

        //  button.Select();

        //ExecuteEvents.Execute(button.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);

       // oneCheck = false;
    }


    public void ButtonReleased()
    {
      
    }


    public void LongClickAction()
    {
        longPress = true;
    }
}
