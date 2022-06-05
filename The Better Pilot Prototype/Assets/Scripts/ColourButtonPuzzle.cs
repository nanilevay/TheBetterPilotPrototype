using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ColourButtonPuzzle : MonoBehaviour
{
    public Button[] buttons;

    //public TextMeshProUGUI textArea;

    public bool PressingGreen = false;

    public bool PressingBlack = false;

    public string code;

    public GameManager Manager;

    public PuzzlePiece PuzzleToSolve;

    public CodeController codeController;

    public TextMeshProUGUI TextToUpdate;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(GreenClick);

        buttons[1].GetComponent<Button>().onClick.AddListener(BlackClick);

        //buttons[0].GetComponent<Button>().OnPointerUp.AddListener(GreenRelease);

        //buttons[1].GetComponent<Button>().OnPointerUp.AddListener(BlackRelease);


        buttons[2].GetComponent<Button>().onClick.AddListener(YellowClick);

        buttons[3].GetComponent<Button>().onClick.AddListener(BlueClick);

        buttons[4].GetComponent<Button>().onClick.AddListener(RedClick);
    }


    void GreenClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            if (!PressingGreen && !PressingBlack)
            {
                PressingGreen = true;
            }

            if (PressingBlack)
                code += "g";
        }
    }

    void BlackClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            if (!PressingBlack && !PressingGreen)
            {
                PressingBlack = true;
            }

            if (PressingGreen)
                code += "z";
        }
    }

    public void GreenRelease()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            PressingGreen = false;
        }
    }

    public void BlackRelease()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            PressingBlack = false;
        }
    }

    void YellowClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            code += "y";
        }
    }

    void BlueClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            code += "b";
        }
    }

    void RedClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            code += "r";
        }
    }

    public void Erase()
    {
        GreenRelease();
        BlackRelease();
        code = "";
        
    }

    void Update()
    {
        TextToUpdate.text = code;

        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            if (Input.GetKeyDown("space"))
            {
                GreenRelease();
                BlackRelease();
                Erase();
            }

            if (PressingGreen)
            {
                BlackRelease();
            }

            if (PressingBlack)
            {
                GreenRelease();
            }

            CheckAnswer();
        }

        else
        {
            PuzzleToSolve.solved = false;
        }
    }

    public void CheckAnswer()
    {
        if (code == "ybbrbybz" && PressingGreen && !Manager.SerialEven && Manager.SerialThree)
        {
            codeController.RemoveCodes("9649");
            PuzzleToSolve.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("9649");
            code = "";
        }

        if (code == "brgyggrg" && PressingBlack && Manager.SerialEven && Manager.SerialThree)
        {
            codeController.RemoveCodes("9649");
            PuzzleToSolve.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("9649");
            code = "";
        }

        if (code == "byryrbbb" && PressingBlack && !Manager.SerialEven && !Manager.SerialThree)
        {
            codeController.RemoveCodes("9649");
            PuzzleToSolve.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("9649");
            code = "";
        }

        if (code == "ryybrrby" && PressingGreen && Manager.SerialEven && !Manager.SerialThree)
        {
            codeController.RemoveCodes("9649");
            PuzzleToSolve.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("9649");
            code = "";
        }
    }


}
