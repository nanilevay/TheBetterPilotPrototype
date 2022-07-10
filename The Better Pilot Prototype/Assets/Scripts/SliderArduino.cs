using UnityEngine;
using UnityEngine.UI;
public class SliderArduino : MonoBehaviour
{
    public Slider slider;

    public SensorListener Sensor;

    // Update is called once per frame
    void Update()
    {
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}