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

    public GameManager Manager;

    public PuzzlePiece AssociatedPuzzle;

    public CodeController codeController;

    public TextMeshProUGUI DisplayText;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(LongClick);

        buttons[1].GetComponent<Button>().onClick.AddListener(ShortClick);
    }

    void LongClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("2197"))
        {
            if (buttons[0].GetComponent<buttonArduino>().oneCheck)
            {
                DecodingText += "-";
                buttons[0].GetComponent<buttonArduino>().oneCheck = false;
            }
        }
    }

    void ShortClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("2197"))
        {
            if (buttons[1].GetComponent<buttonArduino>().oneCheck)
            {
                DecodingText += ".";
                buttons[1].GetComponent<buttonArduino>().oneCheck = false;
            }
        }

        else
        {
            AssociatedPuzzle.solved = false;
            textArea.text = "";
        }
    }


    void Confirm()
    {
        if (buttons[0].GetComponent<LongClickButton>().pointerDown && buttons[1].GetComponent<LongClickButton>().pointerDown)
        {
            Translate();
        }

        if (buttons[0].GetComponent<buttonArduino>().longPress && buttons[1].GetComponent<buttonArduino>().longPress)
        {
            DecodingText = "";
            textArea.text = "";
        }

        if(buttons[1].GetComponent<LongClickButton>().tap == 1)
        {
            DecodingText += ".";
            buttons[1].GetComponent<LongClickButton>().tap = 0;
        }

        if (buttons[0].GetComponent<LongClickButton>().tap == 1)
        {
            DecodingText += "-";
            buttons[0].GetComponent<LongClickButton>().tap = 0;
        }


        if (buttons[0].GetComponent<LongClickButton>().DoubleTap && buttons[1].GetComponent<LongClickButton>().DoubleTap)
        {
            Translate();

            buttons[0].GetComponent<LongClickButton>().DoubleTap = false;


            buttons[1].GetComponent<LongClickButton>().DoubleTap = false;
        }

        if (buttons[0].GetComponent<LongClickButton>().hold && buttons[1].GetComponent<LongClickButton>().hold)
        {
            DecodingText = "";
            textArea.text = "";
        }
    }

    public void ButtonConfirm()
    {
        Translate();
    }

    public void EraseWithButton()
    {
        DecodingText = "";
        textArea.text = "";
    }

    void Update()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("2197"))
        {
            Confirm();
            CheckAnswer();
        }

        DisplayText.text = DecodingText;
    }

    public void CheckAnswer()
    {
        if (Manager.SerialEven && Manager.SerialThree && textArea.text.Contains("SOS"))
        {
            codeController.RemoveCodes("2197");
            AssociatedPuzzle.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("2197");
            DecodingText = "";
            textArea.text = "";
        }
            
        if (!Manager.SerialEven && Manager.SerialThree && textArea.text.Contains("HELP"))
        {
            codeController.RemoveCodes("2197");
            AssociatedPuzzle.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("2197");
            DecodingText = "";
            textArea.text = "";
        }

        if (!Manager.SerialThree && textArea.text.Contains(Manager.SerialNumberDisplay.text))
        {
            codeController.RemoveCodes("2197");
            AssociatedPuzzle.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("2197");
            DecodingText = "";
            textArea.text = "";
        }
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
        if (DecodingText.Equals("..."))
        {
            tempText = "S";
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
