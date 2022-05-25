using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MorseCodeReceived : MonoBehaviour
{
    [SerializeField]
    private GameObject Lighter;

    [SerializeField]
    private string Sequence;

    IEnumerator MorseDisplay()
    {
        while (true)
        {
            foreach (char character in Sequence)
            {
                if (character == '.')
                {
                    // activate() method
                    Lighter.GetComponent<Image>().color = Color.blue;
                    yield return new WaitForSeconds(0.5f);
                    Lighter.GetComponent<Image>().color = Color.black;
                    yield return new WaitForSeconds(0.5f);
                }

                if (character == '-')
                {
                    Lighter.GetComponent<Image>().color = Color.blue;
                    yield return new WaitForSeconds(1.5f);
                    Lighter.GetComponent<Image>().color = Color.black;
                    yield return new WaitForSeconds(0.5f);
                }

                if (character == ' ')
                {
                    Lighter.GetComponent<Image>().color = Color.black;
                    yield return new WaitForSeconds(1.5f);
                }

                if (character == '/')
                {
                    Lighter.GetComponent<Image>().color = Color.black;
                    yield return new WaitForSeconds(2.5f);
                }
            }

            Lighter.GetComponent<Image>().color = Color.black;
            yield return new WaitForSeconds(2);
        }
    }

    void Start()
    {
        StartCoroutine(MorseDisplay());
    }
}
