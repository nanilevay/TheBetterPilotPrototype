using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

public class CodeController : MonoBehaviour
{
    public DisplayUpdater ScreenCodes;

    public TextMeshProUGUI[] textDisplays;

    public int Counter = 0;

    public AudioSource RemoveCodeSound;

    public string One, Two, Three, Four;

    // Start is called before the first frame update
    void Start()
    {

        One = textDisplays[0].text;
        Two = textDisplays[1].text;
        Three = textDisplays[2].text;
        Four = textDisplays[3].text;

    }

    // Update is called once per frame
    void Update()
    {
        //if (Counter < ScreenCodes.currentCodes.Count)
        //{
        //    StartCoroutine(UpdateCodes());
        //    Counter++;
        //}

        One = textDisplays[0].text;
        Two = textDisplays[1].text;
        Three = textDisplays[2].text;
        Four = textDisplays[3].text;

    }

    public void CodeUpdate(string addingCode)
    {
        StartCoroutine(UpdateCodes(addingCode));
    }

    public void ResetCodes()
    {
        StartCoroutine(CodeReset());
    }

    IEnumerator CodeReset()
    {
        foreach (TextMeshProUGUI Code in textDisplays)
        {
            
            Code.text = "    ";
            
        }

        yield break;
    }

    IEnumerator UpdateCodes(string addingCode)
    {
        foreach (TextMeshProUGUI Code in textDisplays)
        {
            if (Code.text.Contains("    ") || Code.text.Contains("####"))
            {
                   Code.text = addingCode;
                   break;

            }
        }

        yield break;
    }

    public void RemoveCodes(string removingCode)
    {
        StartCoroutine(RemoveCode(removingCode));
    }


    IEnumerator RemoveCode(string removingCode)
    {
        Counter--;

        foreach (TextMeshProUGUI Code in textDisplays)
        { 
            if (Code.text.Contains(removingCode))
            {
                Code.text = "    ";
                RemoveCodeSound.Play();
                break;
            }
            
        }

        yield break;
    }
}


