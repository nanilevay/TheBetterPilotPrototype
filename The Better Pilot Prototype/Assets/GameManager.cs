using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PuzzlePiece[] PuzzleComponents;

    public TextMeshProUGUI textDisplay;

    // Update is called once per frame
    void Update()
    {
        foreach(PuzzlePiece piece in PuzzleComponents)
        {
            if(piece.active)
            {
                ActiveUpdater(piece.name);
            }

            else
            {
                InactiveUpdater();
            }
        }
    }

    public void ActiveUpdater(string name)
    {
        textDisplay.text += "\n" + name;
    }

    public void InactiveUpdater()
    {
        textDisplay.text = "";
    }
}
