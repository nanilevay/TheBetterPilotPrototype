using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MorseCode : MonoBehaviour
{
    public Button[] buttons;

    public TextMeshProUGUI textArea;

    public string DecodingText;

    bool BothPressed;

    public Image Led;

    public GameManager Manager;

    public PuzzlePiece AssociatedPuzzle;

    public CodeController codeController;

    public TextMeshProUGUI DisplayText;

    public bool Once = true;

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
            Translate();
        }

        
        if(buttons[1].GetComponent<LongClickButton>().tap == 1) // && buttons[0].GetComponent<LongClickButton>().tap == 0
        {
            DecodingText += ".";
            buttons[1].GetComponent<LongClickButton>().tap = 0;
        }

        if (buttons[0].GetComponent<LongClickButton>().tap == 1) // && buttons[1].GetComponent<LongClickButton>
        {
            DecodingText += "-";
            buttons[0].GetComponent<LongClickButton>().tap = 0;
        }

        if (buttons[0].GetComponent<LongClickButton>().DoubleTap 
            && buttons[1].GetComponent<LongClickButton>().DoubleTap)
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
    

        if(!AssociatedPuzzle.solved && Once)
        {
            StartCoroutine(StartPuzzle());
            Once = false;
        }

        if (Manager.CodeDisplayer.currentCodes.Contains("2197"))
        {
            Confirm();
            CheckAnswer();
        }

        DisplayText.text = DecodingText;
    }

    public void CheckAnswer()
    {
        if (Manager.SerialEven && Manager.SerialThree && 
            textArea.text.Equals("... --- ..."))
        {
            codeController.RemoveCodes("2197");
            AssociatedPuzzle.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("2197");
            DecodingText = "";
            textArea.text = "";
        }
            
        if (!Manager.SerialEven && Manager.SerialThree &&
            textArea.text.Equals(".... . .-.. .--."))
        {
            codeController.RemoveCodes("2197");
            AssociatedPuzzle.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("2197");
            DecodingText = "";
            textArea.text = "";
        }

        if (!Manager.SerialThree && textArea.text.Equals
            ("-- .- -.-- -.. .- -.--"))
        {
            codeController.RemoveCodes("2197");
            AssociatedPuzzle.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("2197");
            DecodingText = "";
            textArea.text = "";
        }
    }

    public IEnumerator StartPuzzle()
    {
        Debug.Log("in");

        while (Manager.CodeDisplayer.currentCodes.Contains("2197"))
        {
            Led.color = Color.red;
            yield return new WaitForSeconds(1f);
            Led.color = Color.black;
            yield return new WaitForSeconds(1f);
            Led.color = Color.red;
            yield return new WaitForSeconds(1f);
            Led.color = Color.black;
            yield return new WaitForSeconds(1f);

       }

    Once = true;
        //DecodingText = "";
        //textArea.text = "";

        yield break;
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