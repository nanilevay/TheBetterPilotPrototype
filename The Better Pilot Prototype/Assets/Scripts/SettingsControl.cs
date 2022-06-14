using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{

    public Slider CodeSpeed;

    public Slider ServoSpeed;

    public Slider ResetCounter;

    public Slider MusicVolume;

    public Toggle ServoOnOff;

    public Toggle FullScreen;

    public Toggle SoundsOnOff;

    public GameObject SoundsObject;

    public AudioSource[] Sounds;

    public bool MainMenu;

    // Start is called before the first frame update

    void Awake()
    {
        CodeSpeed.value = GamePrefs.NewCodeSpeed;

        ServoSpeed.value = GamePrefs.ServoSpeed;

        ResetCounter.value = GamePrefs.ResetCounter;

        MusicVolume.value = GamePrefs.MusicVol;

        ServoOnOff.isOn = GamePrefs.ServoOn;

        SoundsOnOff.isOn = GamePrefs.SoundOn;

        foreach (AudioSource Sound in Sounds)
        {
            Sound.volume = GamePrefs.MusicVol;
        }

    }

    public void ToggleOnOff()
    {
        if (ServoOnOff.isOn)
        {
            ServoOnOff.isOn = false;
            GamePrefs.ServoOn = false;
        }

        else
        {
            GamePrefs.ServoOn = true;
            ServoOnOff.isOn = true;
        }

        Debug.Log(ServoOnOff.isOn);
    }


    void Start()
    {
        CodeSpeed.value = GamePrefs.NewCodeSpeed;

        ServoSpeed.value = GamePrefs.ServoSpeed;

        ResetCounter.value = GamePrefs.ResetCounter;

        MusicVolume.value = GamePrefs.MusicVol;

        ServoOnOff.isOn = GamePrefs.ServoOn;

        SoundsOnOff.isOn = GamePrefs.SoundOn;

        foreach (AudioSource Sound in Sounds)
        {
            Sound.volume = GamePrefs.MusicVol;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu)
        {
            GamePrefs.NewCodeSpeed = (int)CodeSpeed.value;

            GamePrefs.ServoSpeed = (int)ServoSpeed.value;

            GamePrefs.ResetCounter = (int)ResetCounter.value;  

            GamePrefs.ServoOn = ServoOnOff.isOn;       
        }

        GamePrefs.MusicVol = MusicVolume.value;

        GamePrefs.SoundOn = SoundsOnOff.isOn;
    }

    public void ToggleSounds()
    {
        if (SoundsObject.activeSelf)
        {
            SoundsObject.SetActive(false);

        }
        else
        {
            SoundsObject.SetActive(true);
        }
    }

    public void ChangeVolume()
    {
        foreach (AudioSource Sound in Sounds)
        {
            Sound.volume = MusicVolume.value;
        }
    }

    public void ToggleFullScreen()
    {
        if (Screen.fullScreen)
            Screen.fullScreen = false;

        else
            Screen.fullScreen = true;
    }

    public void UpdateSettings()
    {
        GamePrefs.NewCodeSpeed = (int)CodeSpeed.value;

        GamePrefs.ServoSpeed = (int)ServoSpeed.value;

        GamePrefs.ResetCounter = (int)ResetCounter.value;

        GamePrefs.ServoOn = ServoOnOff.isOn;

        GamePrefs.MusicVol = MusicVolume.value;

        GamePrefs.SoundOn = SoundsOnOff.isOn;
    }

        public void ShowValues()
    {
        Debug.Log("Servo: " + GamePrefs.ServoOn + ", sound: " + GamePrefs.SoundOn + ", resets: " + GamePrefs.ResetCounter + ", servo speed: " + GamePrefs.ServoSpeed + ", new code speed: " + GamePrefs.NewCodeSpeed + ", music volume: " + GamePrefs.MusicVol);

        //Debug.Log(SoundsOnOff.isOn);
    }
        
}
