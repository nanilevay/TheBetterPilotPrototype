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

    void Update()
    {
        t += Time.deltaTime;
        if (t >= 3)
        {
            t = 0;
            textDisplay.text = Texts[Random.Range(0, Texts.Count)];
        }
    }
}
