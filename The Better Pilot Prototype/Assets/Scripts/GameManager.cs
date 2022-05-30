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

    public GameObject UduinoManager;

    public bool PhysicalGame = false;

    public TextMeshProUGUI SerialNumberDisplay;

    public DisplayUpdater CodeDisplayer;

    public int ResetCounter = 1;

    public TextMeshProUGUI ResetNumberDisplay;

    public bool SerialEven, SerialThree;

    float t = 0;

    public Toggle[] togglers;

    public bool PlaneOn = false;
    
    public bool checker = true;

    public GameObject ScreenFader;

    public DisplayUpdater CodeReceiver;

    public bool ButtonOn = false;

    public StopWatch stopwatch;

    public Timer timer;


    void Awake()
    {
        int ThreeOrSix = UnityEngine.Random.Range(0, 2); 

        int srlNum;

        if (ThreeOrSix == 0)
            srlNum = UnityEngine.Random.Range(100, 999);
        else
            srlNum = UnityEngine.Random.Range(100000, 999999);

        SerialNumberDisplay.text = srlNum.ToString();

        ScreenFader.transform.Find("InitialScreen").gameObject.active = true;

        if (srlNum.ToString().Length == 3)
        {
            SerialThree = true;
        }
        else
        {
            SerialThree = false;
        }

        if (srlNum % 2 == 0)
        {
            SerialEven = true;
        }
        else
        {
            SerialEven = false;
       }
    }

    void Start()
    {
        UduinoManager = GameObject.FindWithTag("UduinoManager");

        if (PhysicalGame)
            UduinoManager.active = true;
        else
            UduinoManager.active = false;

        int srlNum = 1000;

        SerialNumberDisplay.text = srlNum.ToString();   

    }

    // Update is called once per frame
    void Update()
    {
        if (togglers[0].GetComponent<Toggle>().isOn && togglers[1].GetComponent<Toggle>().isOn && ButtonOn && checker)
        {
            stopwatch.StartStopWatch();
            PlaneOn = true;
            checker = false;

            ScreenFader.transform.Find("InitialScreen").gameObject.active = false;
        }

        if (PlaneOn && stopwatch.stopWatchActive)
        {
            t += Time.deltaTime;

            if (t >= 3)
            {
                UpdateList();
            }

            ResetNumberDisplay.text = ResetCounter.ToString();
        }


        //if(CodeReceiver.CurrentCode == "")
        //    PuzzlesToToggle.AssociatedPuzzle[0].ToggleOn();

        //foreach (PuzzlePiece piece in PuzzlesToToggle.AssociatedPuzzle)
        //{
        //    if (piece.solved)
        //        piece.ToggleOff();
        //}

    }

    public void UpdateList()
    {
        string tempText = "";

        int i = 0;

        foreach(string code in CodeDisplayer.currentCodes)
        {
            tempText += "\n" + CodeDisplayer.currentCodes[i];

            i++; 
        }

        textDisplay.text = tempText;
    }

    public void RemoveItem(int ChosenIndex)
    {
        CodeDisplayer.currentCodes.RemoveAt(ChosenIndex);
        CodeDisplayer.i--;
    }

    public void ResetList()
    {
        if (ResetCounter > 0 && CodeDisplayer.currentCodes.Contains("5790"))
        {
            CodeDisplayer.currentCodes.Clear();

            ResetCounter--;

            CodeDisplayer.i = 0;

            timer.StopTimer();

            timer.Start();
        }
    }

    public void TurnOnPlane()
    {
        ButtonOn = true;
    }

    //void Start()
    //{
    //    StartCoroutine(coroutineA());
    //}

    //IEnumerator coroutineA()
    //{
    //    // wait for 1 second
    //    yield return new WaitForSeconds(1.0f);
    //    Debug.Log("coroutineA() started: " + Time.time);

    //    // wait for another 1 second and then create b
    //    yield return new WaitForSeconds(1.0f);
    //    Coroutine b = StartCoroutine(coroutineB());

    //    yield return new WaitForSeconds(2.0f);
    //    Debug.Log("coroutineA() finished " + Time.time);

    //    // B() was expected to run for 10 seconds
    //    // but was shut down here after 3.0f
    //    StopCoroutine(b);
    //    yield return null;
    //}
}

