using UnityEngine;
using UnityEngine.UI;

public class PuzzleActivator : MonoBehaviour
{
    public PuzzlePiece[] AssociatedPuzzle;
    public LEDs led;
    public Image LEDColour;

    public Color InitialColor;

    public void Start()
    {
        InitialColor = led.LedMaterial.color;
    }
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
        LEDColour.color = InitialColor;
        led.GetComponent<Toggle>().isOn = true;
        
    }

    public void ToggleOff()
    {
        foreach (PuzzlePiece Piece in AssociatedPuzzle)
        {
            Piece.ToggleOff();
        }
        LEDColour.color = Color.black;
        led.GetComponent<Toggle>().isOn = false;
        
    }
}
