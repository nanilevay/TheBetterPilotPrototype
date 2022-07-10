using UnityEngine;
using UnityEngine.UI;

public class SerialCodePuzzle : MonoBehaviour
{
    public Button YellowButton;

    public Button BlueButton;

    public Button BlackButton;

    public Button GreenButton;

    public PuzzlePiece AssociatedPuzzle;

    public GameManager Manager;

    public bool Once = true;

    public CodeController codeController;

    // Start is called before the first frame update
    void Start()
    {
        AssociatedPuzzle.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.CodeReceiver.currentCodes.Contains("0588") && Once)
        {         
            AssociatedPuzzle.solved = false;
            AssociatedPuzzle.active = true;
            Once = false;
        }

        else
        {
            AssociatedPuzzle.solved = false;
        }

        if(!AssociatedPuzzle.solved)
        {
            Checker();
        }

    }

    public void Checker()
    {
        if(!Manager.SerialEven && Manager.SerialThree && BlackButton.GetComponent<LongClickButton>().hold)
        {
            codeController.RemoveCodes("0588");
            AssociatedPuzzle.solved = true;
            BlackButton.GetComponent<LongClickButton>().hold = false;
            Once = true;
            Manager.CodeDisplayer.currentCodes.Remove("0588");
        }

        if (Manager.SerialEven && Manager.SerialThree && GreenButton.GetComponent<LongClickButton>().tap == 1 && YellowButton.GetComponent<LongClickButton>().tap == 1)
        {
            codeController.RemoveCodes("0588");
            GreenButton.GetComponent<LongClickButton>().tap = 0;
            YellowButton.GetComponent<LongClickButton>().tap = 0;
            AssociatedPuzzle.solved = true;
            Once = true;
            Manager.CodeDisplayer.currentCodes.Remove("0588");
        }

        if (!Manager.SerialEven && !Manager.SerialThree && BlueButton.GetComponent<LongClickButton>().tap == 1)
        {
            codeController.RemoveCodes("0588");
            BlueButton.GetComponent<LongClickButton>().tap = 0;
            AssociatedPuzzle.solved = true;
            Once = true;
            Manager.CodeDisplayer.currentCodes.Remove("0588");
        }

        if (Manager.SerialEven && !Manager.SerialThree && BlackButton.GetComponent<LongClickButton>().tap == 1 && YellowButton.GetComponent<LongClickButton>().tap == 1)
        {
            codeController.RemoveCodes("0588");
            BlackButton.GetComponent<LongClickButton>().hold = false;
            YellowButton.GetComponent<LongClickButton>().hold = false;
            AssociatedPuzzle.solved = true;
            Once = true;
            Manager.CodeDisplayer.currentCodes.Remove("0588");
        }
    }
}