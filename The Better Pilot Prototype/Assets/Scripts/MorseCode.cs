using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MorseCode : MonoBehaviour
{
    public Button[] buttons;

    public TextMeshProUGUI textArea;

    public string DecodingText;

    bool BothPressed;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(LongClick);

        buttons[1].GetComponent<Button>().onClick.AddListener(ShortClick);
    }

    void LongClick()
    {
        DecodingText += "-";
    }

    void ShortClick()
    {
        DecodingText += ".";
    }


    void Confirm()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Translate();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            textArea.text = "";
        }
    }

    void Update()
    {
        Confirm();
        CheckAnswer();
    }

    public void CheckAnswer()
    {
        if (textArea.text.Contains("PIZZA"))
            Debug.Log("yes");
    }

    public void Translate()
    {
        string tempText = "";

        if(DecodingText.Equals(".-"))
        {
            tempText = "A";
        }
        if (DecodingText.Equals("-..."))
        {
            tempText = "B";
        }
        if (DecodingText.Equals("-.-."))
        {
            tempText = "C";
        }
        if (DecodingText.Equals("-.."))
        {
            tempText = "D";
        }
        if (DecodingText.Equals("."))
        {
            tempText = "E";
        }
        if (DecodingText.Equals("..-."))
        {
            tempText = "F";
        }
        if (DecodingText.Equals("--."))
        {
            tempText = "G";
        }
        if (DecodingText.Equals("...."))
        {
            tempText = "H";
        }
        if (DecodingText.Equals(".."))
        {
            tempText = "I";
        }
        if (DecodingText.Equals(".---"))
        {
            tempText = "J";
        }
        if (DecodingText.Equals("-.-"))
        {
            tempText = "K";
        }
        if (DecodingText.Equals(".-.."))
        {
            tempText = "L";
        }
        if (DecodingText.Equals("--"))
        {
            tempText = "M";
        }
        if (DecodingText.Equals("-."))
        {
            tempText = "N";
        }
        if (DecodingText.Equals("---"))
        {
            tempText = "O";
        }
        if (DecodingText.Equals(".--."))
        {
            tempText = "P";
        }
        if (DecodingText.Equals("--.-"))
        {
            tempText = "Q";
        }
        if (DecodingText.Equals(".-."))
        {
            tempText = "R";
        }
        if (DecodingText.Equals("..."))
        {
            tempText = "S";
        }
        if (DecodingText.Equals("-"))
        {
            tempText = "T";
        }
        if (DecodingText.Equals("..-"))
        {
            tempText = "U";
        }
        if (DecodingText.Equals("...-"))
        {
            tempText = "V";
        }
        if (DecodingText.Equals(".--"))
        {
            tempText = "W";
        }
        if (DecodingText.Equals("-..-"))
        {
            tempText = "X";
        }
        if (DecodingText.Equals("-.--"))
        {
            tempText = "Y";
        }
        if (DecodingText.Equals("--.."))
        {
            tempText = "Z";
        }
        if (DecodingText.Equals("-----"))
        {
            tempText = "0";
        }
        if (DecodingText.Equals(".-----"))
        {
            tempText = "1";
        }
        if (DecodingText.Equals("..---"))
        {
            tempText = "2";
        }
        if (DecodingText.Equals("...--"))
        {
            tempText = "3";
        }
        if (DecodingText.Equals("....-"))
        {
            tempText = "4";
        }
        if (DecodingText.Equals("....."))
        {
            tempText = "5";
        }
        if (DecodingText.Equals("-...."))
        {
            tempText = "6";
        }
        if (DecodingText.Equals("--..."))
        {
            tempText = "7";
        }
        if (DecodingText.Equals("---.."))
        {
            tempText = "8";
        }
        if (DecodingText.Equals("----."))
        {
            tempText = "9";
        }

        DecodingText = "";
        textArea.text += tempText;
    }
}
