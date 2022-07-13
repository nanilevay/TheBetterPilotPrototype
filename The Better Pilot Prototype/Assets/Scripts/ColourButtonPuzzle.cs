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
            if (!PressingGreen && !PressingBlack)
            {
                PressingGreen = true;
            }

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
            if (!PressingBlack && !PressingGreen)
            {
                PressingBlack = true;
            }

            if (PressingGreen)
                code += "z";

            Once = false;

            StartCoroutine(Release());
        }
    }

    public void GreenRelease()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
        {
            PressingGreen = false;
            Once = false;
            StartCoroutine(Release());
        }
    }

    public void BlackRelease()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("9649") && Once)
        {
            PressingBlack = false;
            Once = false;
            StartCoroutine(Release());
        }
    }

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

    public IEnumerator Release()
    {
        yield return new WaitForSeconds(1);
        Once = true;
        yield break;
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