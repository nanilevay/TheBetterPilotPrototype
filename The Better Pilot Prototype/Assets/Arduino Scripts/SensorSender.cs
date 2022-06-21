using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public StopWatch Watch;


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

    

    void FixedUpdate()
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

            int index2 = 0;

            foreach (char C in Display.One)
            {
                ScreenText[index2] = (byte)C;

                index2++;
            }


            int index3 = 4;

            foreach (char C in Display.Two)
            {
                ScreenText[index3] = (byte)C;

                index3++;
            }

            int index4 = 8;

            foreach (char C in Display.Three)
            {
                ScreenText[index4] = (byte)C;

                index4++;
            }

            int index5 = 12;

            foreach (char C in Display.Four)
            {
                ScreenText[index5] = (byte)C;

                index5++;
            }


            if (ExtraCode.currentCodes.Contains("5790"))
            {
                int index6 = 16;

                foreach (char C in "5790")
                {
                    ScreenText[index6] = (byte)C;

                    index6++;
                }
            }

            int index7 = 20;

            foreach (char C in Manager.SerialNumberDisplay.text)
            {
                ScreenText[index7] = (byte)C;

                index7++;
            }
        }

        else
        {
            ServoNum[0] = 0;

            int index1 = 0;

            foreach (char C in "GAMEOVER")
            {
                ScreenText[index1] = (byte)C;

                index1++;
            }

            int index2 = 9;
            foreach (char C in Watch.FinalScore.text)
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
            

        if (sendData)
        {
            serialController.SendSerialMessage(ServoNum);
            serialController.SendSerialMessage(ScreenText);
            serialController.SendSerialMessage(byteArray);
        }
              
    }
}