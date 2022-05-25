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

    float t = 0;

    void Awake()
    {
        int ThreeOrSix = UnityEngine.Random.Range(0, 2); 

        int srlNum;

        if (ThreeOrSix == 0)
            srlNum = UnityEngine.Random.Range(100, 999);
        else
            srlNum = UnityEngine.Random.Range(100000, 999999);

        SerialNumberDisplay.text = srlNum.ToString();
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
        t += Time.deltaTime;

        if (t >= 3)
        {
            UpdateList();
        }

        ResetNumberDisplay.text = ResetCounter.ToString();
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
        if (ResetCounter > 0)
        {
            CodeDisplayer.currentCodes.Clear();

            ResetCounter--;

            CodeDisplayer.i = 0;
        }
    }
}

