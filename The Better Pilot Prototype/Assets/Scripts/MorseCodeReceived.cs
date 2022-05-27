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

    public Slider mainSlider;

    public PuzzlePiece associatedPuzzle;

    public bool switcher;


    // green, black, blue, yellow, red
    public Button[] buttons;

    void Update()
    {
        if(associatedPuzzle.active && switcher)
            WordGenerator();

        if (!associatedPuzzle.active)
            switcher = true;
    }

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

    void PuzzleConfirmation()
    {
        switch (Sequence)
        {
            case "":
                break;
        }
    }

    void WordGenerator()
    {
        int decider = UnityEngine.Random.Range(0, 7);

        if (decider == 0)
            Sequence = ".";
        
        if (decider == 1)
            Sequence = "..";
        
        if (decider == 2)
            Sequence = "-";
        
        if (decider == 3)
            Sequence = ".-./";
        
        if (decider == 4)
            Sequence = "";
        
        if (decider == 5)
            Sequence = "";
       
        if (decider == 6)
            Sequence = "";

        switcher = false;
    }

}
