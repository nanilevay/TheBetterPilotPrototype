using System.Collections.Generic;
using UnityEngine;

public class OutputSender : MonoBehaviour
{
    public List<Color> colorList = new List<Color>();

    public ServoRotation ServoObject;

    public List<LEDs> LEDList;

    public CodeController Display;

    public DisplayUpdater ExtraCode;

    public GameManager Manager;

    public GameObject GameOver;

    public GameObject PauseMenu;

    public StopWatch Watch;

    public GameObject InfoPanel;

    public GameObject Settings;

    public bool MainMenu;

    public bool LoadingMenu;

    void Update()
    {
        //if (!MainMenu && !LoadingMenu)
        //{
        //    if (PauseMenu.activeSelf)
        //    {
        //        int indexi = 0;

        //        foreach (char C in "PAUSED")
        //        {
        //            ScreenText[indexi] = (byte)C;

        //            indexi++;
        //        }
        //    }

        //    if (InfoPanel.activeSelf)
        //    {
        //        int indexi = 0;

        //        foreach (char C in "INFO")
        //        {
        //            ScreenText[indexi] = (byte)C;

        //            indexi++;
        //        }
        //    }


        //    if (Settings.activeSelf)
        //    {
        //        int indexi = 0;

        //        foreach (char C in "SETTINGS")
        //        {
        //            ScreenText[indexi] = (byte)C;

        //            indexi++;
        //        }
        //    }
        //}
    }
}
