using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorSender : MonoBehaviour
{
    public static SensorSender instance;
    public ByteSerialController serialController;
    
    public bool sendData = false;

    public byte[] byteArray;

    public byte[] ServoNum;

    public byte[] ScreenText;

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

    public GameObject[] ScreenColours;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        instance = this;

        for (int i = 0; i < 10; i++)
            colorList.Add(Color.white);

        byteArray = new byte[10*3]; // 10 LEDs, 3 bytes por LED (R, G, B)

        ServoNum = new byte[1];

        ScreenText = new byte[32];

    }


    void Update()
    {
        if(Manager.CodeDisplayer.currentCodes.Contains("6430"))
        {
            foreach(GameObject mat in ScreenColours)
            { 
                if(mat.activeSelf)
                {
                    LEDList[7].LedMaterial.color = 
                        mat.GetComponent<Image>().color;
                }
                    
             }
            
        }

        else
        {
            LEDList[7].LedMaterial.color = Color.green;
        }


        if (!MainMenu && !LoadingMenu)
        {
            if (PauseMenu.activeSelf)
            {
                int indexi = 0;

                foreach (char C in "     PAUSED                     ")
                {
                    ScreenText[indexi] = (byte)C;

                    indexi++;
                }
            }

            if (InfoPanel.activeSelf)
            {
                int indexi = 0;

                foreach (char C in "      INFO                      ")
                {
                    ScreenText[indexi] = (byte)C;

                    indexi++;
                }
            }


            if (Settings.activeSelf)
            {
                int indexi = 0;

                foreach (char C in "    SETTINGS                    ")
                {
                    ScreenText[indexi] = (byte)C;

                    indexi++;
                }
            }
        }
    }
    

    void FixedUpdate()
    {
        //Debug.Log(ScreenText[0]);

        if (MainMenu)
        {
            int index2 = 0;

            foreach (char C in " WELCOME TO THE  BETTER PILOT !!")
            {
                ScreenText[index2] = (byte)C;

                index2++;
            }
        }

        if (LoadingMenu)
        {
            int index2 = 0;

            foreach (char C in "     PLANE       INITIALIZING...")
            {
                ScreenText[index2] = (byte)C;

                index2++;
            }
        }

        else
        {
            if (!GameOver.activeSelf)
            {
                ServoNum[0] = (byte)ServoObject.value;

                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    Color c = colorList[i];
                    //byte r = (byte)Mathf.Round(c.r * 255);
                    //byte g = (byte)Mathf.Round(c.g * 255);
                    //byte b = (byte)Mathf.Round(c.b * 255);

                    byte r = (byte)Mathf.Round(LEDList[i].LedMaterial.color.r * 255);
                    byte g = (byte)Mathf.Round(LEDList[i].LedMaterial.color.g * 255);
                    byte b = (byte)Mathf.Round(LEDList[i].LedMaterial.color.b * 255);

                    colorList[i] = LEDList[i].LedMaterial.color;

                    byteArray[index++] = r;
                    byteArray[index++] = g;
                    byteArray[index++] = b;

                }

                if (!PauseMenu.activeSelf && !InfoPanel.activeSelf && !Settings.activeSelf)
                {
                    string temp = new string("");

                    temp += Display.One;

                    temp += " ";

                    temp += Display.Two;

                    temp += "|  ";

                    if (ExtraCode.currentCodes.Contains("5790"))
                    {
                        temp += "5790";
                    }

                    else
                    {
                        temp += "####";
                    }

                    temp += Display.Three;

                    temp += " ";

                    temp += Display.Four;

                    temp += "|";

                    if (Manager.SerialNumberDisplay.text.Length > 3)
                        temp += "" + Manager.SerialNumberDisplay.text;

                    else
                        temp += "   " + Manager.SerialNumberDisplay.text;

                    int count = 0;

                    foreach(char C in temp)
                    {
                        ScreenText[count] = (byte)C;
                        count++;
                    }
                }
            }

            else
            {
                ServoNum[0] = 0;

                int index1 = 0;

                foreach (char C in "    GAME OVER    ")
                {
                    ScreenText[index1] = (byte)C;

                    index1++;
                }

                int index2 = 16;

                foreach (char C in "     " + Watch.FinalScore.text + "      ")
                {
                    ScreenText[index2] = (byte)C;

                    index2++;
                }


                int index = 0;
                for (int i = 0; i < 10; i++)
                {
                    Color c = colorList[i];

                    byte r = (byte)Mathf.Round(1 * 255);
                    byte g = (byte)Mathf.Round(0 * 255);
                    byte b = (byte)Mathf.Round(0 * 255);

                    colorList[i] = LEDList[i].LedMaterial.color;

                    byteArray[index++] = r;
                    byteArray[index++] = g;
                    byteArray[index++] = b;

                }
            }

        }

        if (sendData)
        {
            serialController.SendSerialMessage(ServoNum);
            serialController.SendSerialMessage(ScreenText);
            serialController.SendSerialMessage(byteArray);
        }
              
    }
}