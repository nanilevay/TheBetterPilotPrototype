using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEDs : MonoBehaviour
{

    public PuzzlePiece AssociatedPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AssociatedPuzzle.active)
        {
            this.GetComponent<Toggle>().isOn = true;
        }

        else
        {
            this.GetComponent<Toggle>().isOn = false;
        }
    }
}
