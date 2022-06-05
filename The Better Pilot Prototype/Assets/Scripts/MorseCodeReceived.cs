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

    public Coroutine coroutine;


    /// puzzles
    public Button YellowButton;

    public Button RedButton;

    public Button BlueButton;

    public Slider SliderComponent;

    public Button BlackButton;

    public Button GreenButton;

    public GameManager Manager;

    public CodeController codeController;

    public TextMeshProUGUI TextOfMorse;

    void Update()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("6595"))
        {
            if (associatedPuzzle.active && !associatedPuzzle.solved && switcher)
                WordGenerator();

            if (!associatedPuzzle.active && !switcher)
            {
                switcher = true;
                Lighter.GetComponent<Image>().color = Color.black;
                StopCoroutine(coroutine);
            }

            if (!associatedPuzzle.solved)
                PuzzleConfirmation();
        }

        else
        {
            associatedPuzzle.solved = false; 
            Lighter.GetComponent<Image>().color = Color.black;
            switcher = true;
        }
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
       // StartCoroutine(MorseDisplay());
    }

    void PuzzleConfirmation()
    {
        switch (Sequence)
        {
            // where's (shown as where s)
            case ".-- .... . .-. . / ...":
                {
                    if (YellowButton.GetComponent<LongClickButton>().hold)
                    {
                        codeController.RemoveCodes("6595");
                        associatedPuzzle.solved = true;
                        Manager.CodeDisplayer.currentCodes.Remove("6595");
                        YellowButton.GetComponent<LongClickButton>().hold = false;
                        switcher = true;
                    }
                    break;
                }

            // where is
            case ".-- .... . .-. . / .. ...":
                {
                    if (Mathf.RoundToInt(mainSlider.value * 100) >= 80)
                    {
                        codeController.RemoveCodes("6595");
                        associatedPuzzle.solved = true;
                        Manager.CodeDisplayer.currentCodes.Remove("6595");
                        switcher = true;
                    }
                    break;
                }

            // wheres
            case ".-- .... . .-. . ...":
                {
                    if (BlackButton.GetComponent<LongClickButton>().tap == 1 && YellowButton.GetComponent<LongClickButton>().tap == 1)
                    {
                        codeController.RemoveCodes("6595");
                        associatedPuzzle.solved = true;
                        Manager.CodeDisplayer.currentCodes.Remove("6595");
                        BlackButton.GetComponent<LongClickButton>().tap = 0;
                        YellowButton.GetComponent<LongClickButton>().tap = 0;
                        switcher = true;
                    }
                    break;
                }

            // likes
            case ".-.. .. -.- . ...":
                {
                    if (Mathf.RoundToInt(mainSlider.value * 100) <= 20)
                    {
                        codeController.RemoveCodes("6595");
                        associatedPuzzle.solved = true;
                        Manager.CodeDisplayer.currentCodes.Remove("6595");
                        switcher = true;
                    }
                    break;
                }

            // you are
            case "-.-- --- ..- / .- .-. .":
                {

                    if (BlueButton.GetComponent<LongClickButton>().hold && YellowButton.GetComponent<LongClickButton>().tap == 1 && GreenButton.GetComponent<LongClickButton>().tap == 1)
                    {
                        codeController.RemoveCodes("6595");
                        associatedPuzzle.solved = true;
                        Manager.CodeDisplayer.currentCodes.Remove("6595");
                        BlueButton.GetComponent<LongClickButton>().hold = false;
                        YellowButton.GetComponent<LongClickButton>().tap = 0;
                        GreenButton.GetComponent<LongClickButton>().tap = 0;
                        switcher = true;

                    }
                    break;
                }

            // youre
            case "-.-- --- ..- .-. .":
                {
                    if (RedButton.GetComponent<LongClickButton>().DoubleTap)
                    {
                        codeController.RemoveCodes("6595");
                        associatedPuzzle.solved = true;
                        Manager.CodeDisplayer.currentCodes.Remove("6595");
                        RedButton.GetComponent<LongClickButton>().DoubleTap = false;
                        switcher = true;
                    }
                    break;
                }


            // your
            case "-.-- --- ..- .-.":
                {
                    if (BlueButton.GetComponent<LongClickButton>().hold && GreenButton.GetComponent<LongClickButton>().hold)
                    {
                        codeController.RemoveCodes("6595");
                        associatedPuzzle.solved = true;
                        Manager.CodeDisplayer.currentCodes.Remove("6595");
                        BlueButton.GetComponent<LongClickButton>().hold = false;
                        GreenButton.GetComponent<LongClickButton>().hold = false;
                        switcher = true;
                    }
                    break;
                }
        }
    }

    void WordGenerator()
    {
        associatedPuzzle.solved = false;

        int decider = UnityEngine.Random.Range(0, 7);

        // where's
        if (decider == 0)
            Sequence = ".-- .... . .-. ./...";
        
        if (decider == 1)
            Sequence = ".-- .... . .-. . / .. ...";
        
        if (decider == 2)
            Sequence = ".-- .... . .-. . ...";
        
        if (decider == 3)
            Sequence = ".-.. .. -.- . ...";
        
        if (decider == 4)
            Sequence = "-.-- --- ..- / .- .-. .";
        
        if (decider == 5)
            Sequence = "-.-- --- ..- .-. .";
       
        if (decider == 6)
            Sequence = "-.-- --- ..- .-.";

        switcher = false;

        TextOfMorse.text = Sequence;

        coroutine = StartCoroutine(MorseDisplay());
    }

}
