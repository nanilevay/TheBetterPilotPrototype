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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Counter < ScreenCodes.currentCodes.Count)
        //{
        //    StartCoroutine(UpdateCodes());
        //    Counter++;
        //}

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
            if (Code.text.Contains("    ") || Code.text.Contains("display"))
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

