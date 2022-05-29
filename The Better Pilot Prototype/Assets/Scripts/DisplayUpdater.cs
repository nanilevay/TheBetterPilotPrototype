using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayUpdater : MonoBehaviour
{
    float t = 0;
    
    public List<string> Texts;

    public TextMeshProUGUI textDisplay;

    public List<string> currentCodes;

    public int i;

    public int maxNumber;

    public bool Updated = false;

    public string CurrentCode;

    public Timer timer;

    void Awake()
    {
        currentCodes = new List<string>(maxNumber);

        i = 0;
    }
    void Update()
    {
        t += Time.deltaTime;

        if (t >= 20 && i < currentCodes.Capacity)
        {
            string addingCode;

            //Debug.Log("in");
            t = 0;

            addingCode = Texts[Random.Range(0, Texts.Count)];

            if(!currentCodes.Contains(addingCode) && !(currentCodes.Contains("5790")))
             {

                textDisplay.text = addingCode;
                currentCodes.Add(addingCode);
                PuzzleActivator(addingCode);

                i++;
            }
        }

        if(i >= currentCodes.Capacity)
        {
            string addingCode;

            addingCode = "5790";

                textDisplay.text = addingCode;
                currentCodes.Add(addingCode);
                PuzzleActivator(addingCode);
                timer.StartTimer();

        }  
    }

    void PuzzleActivator(string checker)
    {
        switch (checker)
        {
            case "5790":
                break;
            case "6595":
                break;
            case "0088":
                break;
            case "6007":
                break;
            case "6430":
                break;
            case "9649":
                break;
            case "0238":
                break;
            case "0588":
                break;
            case "2197":
                break;
            case "2922":
                break;
        }
    }
}
