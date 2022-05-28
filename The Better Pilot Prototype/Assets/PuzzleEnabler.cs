using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class PuzzleEnabler : MonoBehaviour
{
    // switches, green / black bttns, morse, rotator, proximity, display, red / blue / yellow bttns
    public PuzzleActivator[] PuzzleList;

    public PuzzlePiece associatedPuzzle;

    public GameObject ScreenColours;

    public bool switcher;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (associatedPuzzle.active && switcher)
            ConditionGenerator();

        if (!associatedPuzzle.active)
            switcher = true;
    }

    void ConditionGenerator()
    {
        int decider = UnityEngine.Random.Range(0, 2);

        if (decider == 0)
        {
            ScreenColours.transform.Find("Red").gameObject.active = true;

            int component = UnityEngine.Random.Range(0, 6);

            // switches, green / black bttns, morse, rotator, proximity, display, red / blue / yellow bttns
            if (component == 0)
                PuzzleList[0].ToggleOff();
            if (component == 1)
                PuzzleList[1].ToggleOff();
            if (component == 2)
                PuzzleList[2].ToggleOff();
            if (component == 3)
                PuzzleList[3].ToggleOff();
            if (component == 4)
                PuzzleList[4].ToggleOff();
            if (component == 5)
                PuzzleList[5].ToggleOff();
            if (component == 6)
                PuzzleList[6].ToggleOff();
        }

        if (decider == 1)
        {
            ScreenColours.transform.Find("Blue").gameObject.active = true;
        }

        if (decider == 2)
        {
            ScreenColours.transform.Find("Yellow").gameObject.active = true;
        }



        switcher = false;
    }
}
