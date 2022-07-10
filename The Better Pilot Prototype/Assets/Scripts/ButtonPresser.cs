using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPresser : MonoBehaviour
{
    public bool Pressed;

    public int Value, Index;
    public ButtonPresser(bool pressed, int value, int index)
    {
        Pressed = pressed;

        Value = value;

        Index = index;
    }
}
