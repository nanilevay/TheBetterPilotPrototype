using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ServoRotation : MonoBehaviour
{
    public bool active = true;
    [SerializeField] private Canvas m_Canvas;
    public TextMeshProUGUI textDisplay;

    public float value;
    public float manualvalue;
    public int periodLength = GamePrefs.ServoSpeed; //Seconds
    public float amount; //Amount to add

    public float maxVal;
    public float minVal;

    public bool increasing = true;

    public RotateHandle rotator;

    public Toggle[] toggles;

    public bool valid;

    public GameObject GameOver;

    public bool ManualUp;

    public StopWatch Watch;

    public AudioSource WarningSound;

    public bool once = true;

    public void ToggleOnOff()
    {
        if (GamePrefs.ServoOn)
            GamePrefs.ServoOn = false;

        else
            GamePrefs.ServoOn = true;
    }

    void Start()
    {
        periodLength = GamePrefs.ServoSpeed;
    }
    void Update()
    {
        periodLength = GamePrefs.ServoSpeed;

        if (GamePrefs.ServoOn)
        {
            if (value == 0 || value == 180)
            {
                GameOver.SetActive(true);
            }


            if (!rotator.IsMoving)
            {
                if (increasing)
                {
                    value += amount * Time.deltaTime * periodLength;
                }

                else
                {
                    value -= amount * Time.deltaTime * periodLength;
                }

                if (value <= 0)
                {
                    increasing = true;
                    GameOver.SetActive(true);
                    Watch.StopStopWatch();
                    WarningSound.Stop();
                }

                if (value >= 180)
                {
                    increasing = false;
                    GameOver.SetActive(true);
                    Watch.StopStopWatch();
                    WarningSound.Stop();
                }

                if ((value >= 170 || value <= 10) && once)
                {
                    once = false;
                    StartCoroutine(WarningSoundToggle());
                }

                if (value < 170 && value > 10)
                {
                    WarningSound.Stop();
                    once = true;
                }

                RotateObject(value);
            }

            else
            {
                if (Mathf.Round(value) >= 90 && toggles[0].isOn && toggles[1].isOn)
                {
                    ManualUp = true;
                    manualvalue = value -= amount * Time.deltaTime * periodLength * 5;
                }


                if (Mathf.Round(value) < 90 && !toggles[0].isOn && !toggles[1].isOn)
                {
                    manualvalue = value += amount * Time.deltaTime * periodLength * 5;
                    ManualUp = false;
                }


                if (Mathf.Round(value) >= 90 && !toggles[0].isOn && !toggles[1].isOn)
                {
                    manualvalue = value += amount * Time.deltaTime * periodLength * 5;
                    ManualUp = false;
                }


                if (Mathf.Round(value) < 90 && toggles[0].isOn && toggles[1].isOn)
                {
                    ManualUp = true;
                    manualvalue = value -= amount * Time.deltaTime * periodLength * 5;
                }


                if (ManualUp)
                {
                    manualvalue = value -= amount * Time.deltaTime * periodLength * 5;
                }

                if (!ManualUp)
                {
                    manualvalue = value += amount * Time.deltaTime * periodLength * 5;
                }

                RotateObject(value);
            }
            textDisplay.text = Mathf.Round(value).ToString();
        }
    }

    IEnumerator WarningSoundToggle()
    {
        WarningSound.Play();
        once = false;

        yield break;
    }
    public void RotateObject(float valueToRotate)
    {
        transform.rotation = Quaternion.Euler(0, 0, valueToRotate);
        
        if(rotator.IsMoving)
            value = manualvalue;
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}