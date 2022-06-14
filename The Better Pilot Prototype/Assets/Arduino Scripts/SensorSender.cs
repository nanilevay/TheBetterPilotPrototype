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
        
    public List<Color> colorList = new List<Color>();

    public ServoRotation ServoObject;

    public List<LEDs> LEDList;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for(int i = 0; i < 10; i++)
            colorList.Add(Color.white);

        byteArray = new byte[10*3]; // 10 LEDs, 3 bytes por LED (R, G, B)

        ServoNum = new byte[1];

    }

    

    void FixedUpdate()
    {
        ServoNum[0] = (byte)ServoObject.value;

        int index = 0;
        for(int i = 0; i < 10; i++)
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


        if(sendData)
        {
            serialController.SendSerialMessage(ServoNum);
            serialController.SendSerialMessage(byteArray);
        }
              
    }
}