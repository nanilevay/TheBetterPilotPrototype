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

    void Awake()
    {
        currentCodes = new List<string>(maxNumber);

        i = 0;
    }
    void Update()
    {
        t += Time.deltaTime;

        if (t >= 3 && i < currentCodes.Capacity)
        {
            string addingCode;

            Debug.Log("in");
            t = 0;

            addingCode = Texts[Random.Range(0, Texts.Count)];

            textDisplay.text = addingCode;

            currentCodes.Add(addingCode);

            i++;

        }
    }
}
