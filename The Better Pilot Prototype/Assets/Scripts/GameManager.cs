using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public bool EndlessMode = true;

    public PuzzlePiece[] PuzzleComponents;

    public TextMeshProUGUI textDisplay;

    public bool PhysicalGame = false;

    public TextMeshProUGUI SerialNumberDisplay;

    public DisplayUpdater CodeDisplayer;

    public int ResetCounter = GamePrefs.ResetCounter;

    public TextMeshProUGUI ResetNumberDisplay;

    public bool SerialEven, SerialThree;

    float t = 0;

    public Toggle[] togglers;

    public bool PlaneOn = false;

    public bool checker = true;

    public GameObject ScreenFader;

    public DisplayUpdater CodeReceiver;

    public bool ButtonOn = false;

    public StopWatch stopwatch;

    public Timer timer;

    public bool Restart = true;

    public CodeController codeController;

    public int SrlNum;

    public SettingsControl Settings;

    public GameObject SettingsObj;

    public SensorListener Encoder;

    public SensorListener Listener;

    public AudioSource ResetSound;

    public int timer1 = 0;

    void Awake()
    {
        ResetCounter = GamePrefs.ResetCounter;

        Restart = true;

        int ThreeOrSix = UnityEngine.Random.Range(0, 2);

        int srlNum;

        if (ThreeOrSix == 0)
            srlNum = UnityEngine.Random.Range(100, 999);
        else
            srlNum = UnityEngine.Random.Range(100000, 999999);

        SrlNum = srlNum;

        SerialNumberDisplay.text = SrlNum.ToString();

        ScreenFader.transform.Find("InitialScreen").gameObject.active = true;

        if (srlNum.ToString().Length == 3)
        {
            SerialThree = true;
        }
        else
        {
            SerialThree = false;
        }

        if (srlNum % 2 == 0)
        {
            SerialEven = true;
        }
        else
        {
            SerialEven = false;
        }

        StartCoroutine(StartPlaneCheck());
    }

    public void RestartGame()
    {
        if (Restart)
        {
            togglers[0].GetComponent<Toggle>().isOn = false;
            togglers[1].GetComponent<Toggle>().isOn = false;
            stopwatch.StopStopWatch();
            Restart = false;
            checker = false;
            ButtonOn = false;
            Awake();
            Start();
            CodeDisplayer.i = 0;
            CodeDisplayer.currentCodes.Clear();
            Settings.UpdateSettings();
        }

        Application.LoadLevel(2);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);
    }

    void Start()
    {
        SerialNumberDisplay.text = SrlNum.ToString();
        SettingsObj.SetActive(false);
        GamePrefs.EndlessMode = EndlessMode;
    }

    // Update is called once per frame
    void Update()
    {
        timer1 += 1;

        if (Listener.blckMorse == 0 && Listener.blckButton == 0 && timer1 > 3)
        {
            RestartGame();
        }

        if (Encoder.swEncoder == 0)
        {
            ResetList();
            ResetSound.Play();
        }

        // GamePrefs.EndlessMode = EndlessMode;
        EndlessMode = GamePrefs.EndlessMode;

        if (!EndlessMode && CodeReceiver.Texts.Count <= 0)
        {
            GamePrefs.EndlessMode = EndlessMode;
            GamePrefs.LastTimer = stopwatch.currentTimeText.text;
            SceneManager.LoadScene(5);
        }

        ResetCounter = GamePrefs.ResetCounter;

        if (togglers[0].GetComponent<Toggle>().isOn && togglers[1].GetComponent<Toggle>().isOn && Encoder.swEncoder == 0 && checker)
        {
            stopwatch.StartStopWatch();
            PlaneOn = true;
            checker = false;
            ButtonOn = false;

            GamePrefs.ServoOn = true;

            ScreenFader.transform.Find("InitialScreen").gameObject.active = false;
        }

        if (PlaneOn && stopwatch.stopWatchActive)
        {
            t += Time.deltaTime;

            if (t >= 3)
            {
                UpdateList();
            }

            ResetNumberDisplay.text = ResetCounter.ToString();
        }
    }

    public void UpdateList()
    {
        string tempText = "";

        int i = 0;

        foreach (string code in CodeDisplayer.currentCodes)
        {
            tempText += " " + CodeDisplayer.currentCodes[i];

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
        if (ResetCounter > 0 && CodeDisplayer.currentCodes.Contains("5790"))
        {
            CodeDisplayer.currentCodes.Clear();

            ResetCounter--;

            CodeDisplayer.i = 0;

            timer.StopTimer();

            timer.Start();

            codeController.ResetCodes();

        }
    }

    public IEnumerator StartPlaneCheck()
    {
        yield return new WaitForSeconds(3);
        checker = true;
        yield break;
    }

    public void TurnOnPlane()
    {
        ButtonOn = true;
    }
}