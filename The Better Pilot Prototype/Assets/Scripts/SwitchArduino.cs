using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
            ButtonReleased();
        }

        if (buttonValue == 1)
        {
            ButtonClicked();
        }
    }

    public void ButtonClicked()
    {
        toggler.isOn = true;
    }

    public void ButtonReleased()
    {
        toggler.isOn = false;
    }
}