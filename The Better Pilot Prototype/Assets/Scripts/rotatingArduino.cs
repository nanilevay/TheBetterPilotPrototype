using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class rotatingArduino : MonoBehaviour
{
    public Slider slider;

    public RotateHandle rotator;

    public int analogValue;

    // Start is called before the first frame update
    void Start()
    {
       UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void DataReceived(string data, UduinoDevice board)
    {
        float f = float.Parse(data);

        rotator.RotateObject(f / 1000.0f);
    }
}