using UnityEngine;
using UnityEngine.UI;

public class PuzzleActivator : MonoBehaviour
{
    public PuzzlePiece[] AssociatedPuzzle;
    public LEDs led;

    public void TakeAction()
    {
        if (this.GetComponent<Toggle>().isOn)
        {
            ToggleOn();
        }

        else
        {
            ToggleOff();
        }
    }

    public void ToggleOn()
    {
        foreach (PuzzlePiece Piece in AssociatedPuzzle)
        {
            Piece.ToggleOn();
        }

         led.GetComponent<Toggle>().isOn = true;
    }

    public void ToggleOff()
    {
        foreach (PuzzlePiece Piece in AssociatedPuzzle)
        {
            Piece.ToggleOff();
        }

        led.GetComponent<Toggle>().isOn = false;
    }
}
