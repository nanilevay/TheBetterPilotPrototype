using System.Collections.Generic;
using UnityEngine;
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

    public CodeController codeController;

    public AudioSource CodeSound;

    public TMP_InputField CodeInput;

    public List<PuzzlePiece> PuzzlesInGame;
    public void CodeAdder()
    {
        if(CodeInput.text.Length == 4)
        {
            textDisplay.text = CodeInput.text;
            currentCodes.Add(CodeInput.text);
            PuzzleActivator(CodeInput.text);
            codeController.CodeUpdate(CodeInput.text);
            CodeSound.Play();

        }
    }

    public void CodeRemover()
    {
        if (CodeInput.text.Length == 4)
        {

            foreach (PuzzlePiece puzzle in PuzzlesInGame)
            {
                if (puzzle.name == CodeInput.text)
                {
                    if (!GamePrefs.EndlessMode)
                        Texts.Remove(CurrentCode);
                    puzzle.active = false;
                    puzzle.solved = false;
                    currentCodes.Remove(CodeInput.text);
                    codeController.RemoveCodes(CodeInput.text);
                    CodeSound.Play();
                }
            }

        }
    }

    public int TimeBeforeNextCode = GamePrefs.NewCodeSpeed;

    void Awake()
    {
        TimeBeforeNextCode = GamePrefs.NewCodeSpeed;

        currentCodes = new List<string>(maxNumber);

        i = 0;
    }
    void Update()
    {
        TimeBeforeNextCode = GamePrefs.NewCodeSpeed;

        t += Time.deltaTime;

        if (t >= TimeBeforeNextCode && i < currentCodes.Capacity)
        {
            string addingCode;

            t = 0;

            addingCode = Texts[Random.Range(0, Texts.Count)];

            if(!currentCodes.Contains(addingCode) && !(currentCodes.Contains("5790")))
             {

                textDisplay.text = addingCode;
                currentCodes.Add(addingCode);
                PuzzleActivator(addingCode);
                codeController.CodeUpdate(addingCode);
                CodeSound.Play();
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
         i = currentCodes.Count;
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