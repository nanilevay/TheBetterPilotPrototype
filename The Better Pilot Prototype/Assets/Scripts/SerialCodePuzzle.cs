using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SerialCodePuzzle : MonoBehaviour
{
    public Button YellowButton;

    public Button BlueButton;

    public Button BlackButton;

    public Button GreenButton;

    public PuzzlePiece AssociatedPuzzle;

    public GameManager Manager;

    public bool Once = true;

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

        if(!AssociatedPuzzle.solved)
        {
            Checker();
        }

    }

    public void Checker()
    {
        if(!Manager.SerialEven && Manager.SerialThree && BlackButton.GetComponent<LongClickButton>().hold)
        {
            AssociatedPuzzle.solved = true;
            BlackButton.GetComponent<LongClickButton>().hold = false;
            Once = true;
        }

        if (Manager.SerialEven && Manager.SerialThree && GreenButton.GetComponent<LongClickButton>().tap == 1 && YellowButton.GetComponent<LongClickButton>().tap == 1)
        {
            GreenButton.GetComponent<LongClickButton>().tap = 0;
            YellowButton.GetComponent<LongClickButton>().tap = 0;
            AssociatedPuzzle.solved = true;
            Once = true;
        }

        if (!Manager.SerialEven && !Manager.SerialThree && BlueButton.GetComponent<LongClickButton>().tap == 1)
        {
            BlueButton.GetComponent<LongClickButton>().tap = 0;
            AssociatedPuzzle.solved = true;
            Once = true;
        }

        if (Manager.SerialEven && !Manager.SerialThree && BlackButton.GetComponent<LongClickButton>().tap == 1 && YellowButton.GetComponent<LongClickButton>().tap == 1)
        {
            BlackButton.GetComponent<LongClickButton>().hold = false;
            YellowButton.GetComponent<LongClickButton>().hold = false;
            AssociatedPuzzle.solved = true;
            Once = true;
        }
    }
}
