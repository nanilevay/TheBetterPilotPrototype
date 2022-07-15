using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ColourButtonPuzzle : MonoBehaviour
{
    public Button[] buttons;

    public bool PressingGreen = false;

    public bool PressingBlack = false;

    public string code;

    public GameManager Manager;

    public PuzzlePiece PuzzleToSolve;

    public CodeController codeController;

    public TextMeshProUGUI TextToUpdate;

    public SensorListener Sensor;

    public bool Once = true;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(GreenClick);

        buttons[1].GetComponent<Button>().onClick.AddListener(BlackClick);

        buttons[2].GetComponent<Button>().onClick.AddListener(YellowClick);

        buttons[3].GetComponent<Button>().onClick.AddListener(BlueClick);

        buttons[4].GetComponent<Button>().onClick.AddListener(RedClick);
    }

    void GreenClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
        {
            //if (!PressingGreen && !PressingBlack)
            //{
            //    PressingGreen = true;
            //}

            if (PressingBlack)
                code += "g";

            Once = false;
            StartCoroutine(Release());
        }
    }

    void BlackClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
        {
            //if (!PressingBlack && !PressingGreen)
            //{
            //    PressingBlack = true;
            //}

            if (PressingGreen)
                code += "z";

            Once = false;

            StartCoroutine(Release());
        }
    }

    //public void GreenRelease()
    //{
    //    if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
    //    {
    //        PressingGreen = false;
    //        Once = false;
    //        StartCoroutine(Release());
    //    }
    //}

    //public void BlackRelease()
    //{
    //    if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
    //    {
    //        PressingBlack = false;
    //        Once = false;
    //        StartCoroutine(Release());
    //    }
    //}

    void YellowClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
        {
            code += "y";
            Once = false;
            StartCoroutine(Release());
        }
    }

    void BlueClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
        {
            code += "b";
            Once = false;
            StartCoroutine(Release());
        }
    }

    void RedClick()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
        {
            code += "r";
            Once = false;
            StartCoroutine(Release());
        }
    }

    public void Erase()
    {
        code = "";
    }

    void Update()
    {
        //if (code == "g" || code == "z")
        //{
        //    code = "";
        //}

        if (buttons[0].GetComponent<LongClickButton>().hold)
        {
            PressingGreen = true;
        }

        else
        {
            PressingGreen = false;
        }


        if (buttons[1].GetComponent<LongClickButton>().hold)
        {
            PressingBlack = true;
        }

        else
        {
            PressingBlack = false;
        }

        //if (buttons[2].GetComponent<buttonArduino>().oneCheck)
        //{
        //    code += "y";
        //    buttons[2].GetComponent<buttonArduino>().oneCheck = false;
        //}

        //if (buttons[3].GetComponent<buttonArduino>().oneCheck)
        //{
        //    code += "r";
        //    buttons[3].GetComponent<buttonArduino>().oneCheck = false;
        //}

        //if (buttons[4].GetComponent<buttonArduino>().oneCheck)
        //{
        //    code += "b";
        //    buttons[4].GetComponent<buttonArduino>().oneCheck = false;
        //}

        TextToUpdate.text = code;

        if (Manager.CodeDisplayer.currentCodes.Contains("9649"))
        {
            if (Input.GetKeyDown("space"))
            {
                Erase();
            }

            if (PressingGreen && PressingBlack)
            {
                Erase();
            }

            CheckAnswer();
        }

        else
        {
            PuzzleToSolve.solved = false;
        }
    }

    public IEnumerator Release()
    {
        yield return new WaitForSeconds(0.25f);
        Once = true;
        yield break;
    }

    public void CheckAnswer()
    {
        if (code == "ybbrbybz" && PressingGreen && 
            !Manager.SerialEven && Manager.SerialThree)
        {
            codeController.RemoveCodes("9649");
            PuzzleToSolve.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("9649");
            code = "";
        }

        if (code == "brgyggrg" && PressingBlack && 
            Manager.SerialEven && Manager.SerialThree)
        {
            codeController.RemoveCodes("9649");
            PuzzleToSolve.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("9649");
            code = "";
        }

        if (code == "byryrbbb" && PressingBlack && 
            !Manager.SerialEven && !Manager.SerialThree)
        {
            codeController.RemoveCodes("9649");
            PuzzleToSolve.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("9649");
            code = "";
        }

        if (code == "ryybrrby" && PressingGreen && 
            Manager.SerialEven && !Manager.SerialThree)
        {
            codeController.RemoveCodes("9649");
            PuzzleToSolve.solved = true;
            Manager.CodeDisplayer.currentCodes.Remove("9649");
            code = "";
        }
    }
}