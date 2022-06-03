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

    public bool RedOption1, RedOption2, RedOption3, RedOption4;

    public bool YellowOption1, YellowOption2, YellowOption3, YellowOption4;

    public bool BlueOption1, BlueOption2;

    public AudioSource SuccessSound;

    public Button YellowButton;

    public Button RedButton;

    public Button BlueButton;

    public Slider mainSlider;

    public Button BlackButton;

    public Button GreenButton;

    public Button Morse1;

    public Button Morse2;

    public Toggle SwitchOne;

    public Toggle SwitchTwo;

    public ServoRotation Servo;

    public GameManager Manager;

    public CodeController codeController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("6430"))
        {
            associatedPuzzle.active = true;

            if (associatedPuzzle.active && switcher && !associatedPuzzle.solved)
                ConditionGenerator();

            if (!associatedPuzzle.active)
                switcher = true;

            if (associatedPuzzle.solved)
                StartCoroutine(FinishPuzzle());

            if (!associatedPuzzle.solved)
                PuzzleConfirmation();
        }

        else
        {
            associatedPuzzle.solved = false;
            StartCoroutine(FinishPuzzle());
        }
    }


    public void PuzzleConfirmation()
    {
        if(YellowOption1)
        {
            if(YellowButton.GetComponent<LongClickButton>().hold && GreenButton.GetComponent<LongClickButton>().hold)
            {
                YellowButton.GetComponent<LongClickButton>().hold = false;
                GreenButton.GetComponent<LongClickButton>().hold = false;

                associatedPuzzle.solved = true;

                PuzzleList[5].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }
        }

        if (YellowOption2)
        {
            if (Mathf.Round(Servo.value) >= 90 && SwitchOne.isOn && SwitchTwo.isOn)
            {
                associatedPuzzle.solved = true;

                PuzzleList[6].ToggleOn();
                PuzzleList[2].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }

            if (Mathf.Round(Servo.value) < 90 && !SwitchOne.isOn && !SwitchTwo.isOn)
            {
                associatedPuzzle.solved = true;
                PuzzleList[6].ToggleOn();
                PuzzleList[2].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }
        }

        if (YellowOption3)
        {
            if (Mathf.Round(Servo.value) == 45) 
            {
                associatedPuzzle.solved = true;
                PuzzleList[6].ToggleOn();

                StartCoroutine(FinishPuzzle());
            }
        }

        if (YellowOption4)
        {
            if (Mathf.Round(Servo.value) >= 90 && SwitchOne.isOn && SwitchTwo.isOn)
            {
                associatedPuzzle.solved = true;
                PuzzleList[2].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }

            if (Mathf.Round(Servo.value) < 90 && !SwitchOne.isOn && !SwitchTwo.isOn)
            {
                associatedPuzzle.solved = true;
                PuzzleList[2].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }
        }

        if (RedOption1)
        {
            if (Mathf.RoundToInt(mainSlider.value * 100) >= 45 && Mathf.RoundToInt(mainSlider.value * 100) <= 55)
            {
                associatedPuzzle.solved = true;

                PuzzleList[2].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }
        }

        if (RedOption2)
        {
            if (Mathf.Round(Servo.value) == 45)
            {
                associatedPuzzle.solved = true;

                PuzzleList[0].ToggleOn();
                PuzzleList[1].ToggleOn();

                StartCoroutine(FinishPuzzle());
            }
        }

        if (RedOption3)
        {
            if (Morse1.GetComponent<LongClickButton>().hold && Morse2.GetComponent<LongClickButton>().hold)
            {
                
                associatedPuzzle.solved = true;

                PuzzleList[0].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }
        }

        if (RedOption4)
        {
           

            if (BlueButton.GetComponent<LongClickButton>().hold && Mathf.Round(Servo.value) == 60)
            {
                BlueButton.GetComponent<LongClickButton>().hold = false;

                associatedPuzzle.solved = true;

                PuzzleList[1].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }
        }

        if (BlueOption1)
        {
            if (Mathf.Round(Servo.value) >= 90 && SwitchOne.isOn && SwitchTwo.isOn)
            {
                associatedPuzzle.solved = true;

                PuzzleList[3].ToggleOn();

                StartCoroutine(FinishPuzzle());
            }

            if (Mathf.Round(Servo.value) < 90 && !SwitchOne.isOn && !SwitchTwo.isOn)
            {
                associatedPuzzle.solved = true;

                PuzzleList[3].ToggleOn();

                StartCoroutine(FinishPuzzle());

            }
        }

        if (BlueOption2)
        {
            if (Mathf.RoundToInt(mainSlider.value * 100) >= 45 && (YellowButton.GetComponent<LongClickButton>().hold && GreenButton.GetComponent<LongClickButton>().hold && BlueButton.GetComponent<LongClickButton>().hold)) // && tilt)
            {
                YellowButton.GetComponent<LongClickButton>().hold = false;
                GreenButton.GetComponent<LongClickButton>().hold = false;
                BlueButton.GetComponent<LongClickButton>().hold = false;

                associatedPuzzle.solved = true;

                PuzzleList[4].ToggleOn();

                StartCoroutine(FinishPuzzle());
            }
        }
    }

    IEnumerator FinishPuzzle()
    {
        codeController.RemoveCodes("6430");
        Manager.CodeDisplayer.currentCodes.Remove("6430");
        SuccessSound.Play();

        ScreenColours.transform.Find("Yellow").gameObject.active = false;
        ScreenColours.transform.Find("Blue").gameObject.active = false;
        ScreenColours.transform.Find("Red").gameObject.active = false;

        foreach(PuzzleActivator elem in PuzzleList)
        {
            elem.ToggleOn();
        }

        RedOption1 = false;
        RedOption2 = false;
        RedOption3 = false;
        RedOption4 = false;

        YellowOption1 = false;
        YellowOption2 = false;
        YellowOption3 = false;
        YellowOption4 = false;

        BlueOption1 = false;
        BlueOption2 = false;

        switcher = true;

        SuccessSound.Stop();
        yield break;
    }

    public void ConditionGenerator()
    {
        int decider = UnityEngine.Random.Range(0, 30);

        if ((decider >= 0) && (decider < 10))
        {
            ScreenColours.transform.Find("Red").gameObject.active = true;

            int component = UnityEngine.Random.Range(0, 4);

            // switches, green / black bttns, morse, rotator, proximity, display, red / blue / yellow bttns
            if (component == 0)
            {
                PuzzleList[2].ToggleOff();
                RedOption1 = true;
            }
            if (component == 1)
            {
                PuzzleList[0].ToggleOff();
                PuzzleList[1].ToggleOff();
                RedOption2 = true;
            }
            if (component == 2)
            {
                PuzzleList[0].ToggleOff();
                RedOption3 = true;
            }
            if (component >= 3)
            {
                PuzzleList[1].ToggleOff();
                RedOption4 = true;
            }

            Debug.Log(decider + "," + component);

        }

        if ((decider >= 10) && (decider < 20))
        {
            ScreenColours.transform.Find("Blue").gameObject.active = true;

            int component = UnityEngine.Random.Range(0, 2);

            // switches, green / black bttns, morse, rotator, proximity, display, red / blue / yellow bttns
            if (component == 0)
            {
                PuzzleList[3].ToggleOff();
                BlueOption1 = true;
            }
            if (component >= 1)
            {
                PuzzleList[4].ToggleOff();
                BlueOption2 = true;
            }

            Debug.Log(decider + "," + component);
        }

        if ((decider >= 20) && (decider < 30))
        {
            ScreenColours.transform.Find("Yellow").gameObject.active = true;

            int component = UnityEngine.Random.Range(0, 4);

            // switches, green / black bttns, morse, rotator, proximity, display, red / blue / yellow bttns
            if (component == 0)
            {
                PuzzleList[5].ToggleOff();
                YellowOption1 = true;
            }
            if (component == 1)
            {
                PuzzleList[6].ToggleOff();
                PuzzleList[2].ToggleOff();
                YellowOption2 = true;
            }
            if (component == 2)
            {
                PuzzleList[6].ToggleOff();
                YellowOption3 = true;
            }
            if (component >= 3)
            {
                PuzzleList[2].ToggleOff();
                YellowOption4 = true;
            }

            Debug.Log(decider + "," + component);
        }

        

        switcher = false;
    }
}
