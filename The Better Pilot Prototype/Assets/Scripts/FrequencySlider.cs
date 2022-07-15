using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FrequencySlider : MonoBehaviour
{
    public float startingPitch;
    public AudioSource audioSource;
    public AudioSource audioToMatch;
    public TextMeshProUGUI textDisplay;
    public float SliderValue;

    public bool ProximityCheck;

    public Slider mainSlider;

    public PuzzlePiece AssociatedPuzzle;

    public ProximityDetector Detector;

    public bool switcher = true;

    public AudioSource SuccessSound;

    public GameManager Manager;

    public CodeController codeController;

    public SensorListener Sensor;

    void Awake()
    {
        // PitchGenerator();

        audioSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.CodeDisplayer.currentCodes.Contains("0088"))
        {
            if (AssociatedPuzzle.active && switcher)
            {
                PitchGenerator();
                audioSource.pitch = startingPitch;
                audioSource.Play();
            }

            if (!AssociatedPuzzle.active && !switcher)
            {
                switcher = true;
            }

            if (AssociatedPuzzle.active && !switcher)
            {
                if (Detector.ProximityDetected)
                    ProximityCheck = true;
                else
                    ProximityCheck = false;

                SliderValue = map(mainSlider.value, 0f, 1f, 0f, 3f);

                audioToMatch.pitch = SliderValue;

                audioToMatch.volume = map(Sensor.sensor, 0, 20, 0,1);

                if (ProximityCheck && !audioToMatch.isPlaying && !AssociatedPuzzle.solved)
                    audioToMatch.Play();

                if (!ProximityCheck)
                    audioToMatch.Stop();

                if (ProximityCheck && Mathf.Round(SliderValue * 10.0f) * 0.1f == Mathf.Round(startingPitch * 10.0f) * 0.1f && Detector.ProximityDetected)
                {
                    StartCoroutine(Stop());

                }
            }

            else if (!AssociatedPuzzle.active)
            {
                audioSource.Stop();
                audioToMatch.Stop();
            }
        }

        else
        {
            AssociatedPuzzle.solved = false;
            switcher = true;
            audioSource.Stop();
        }
    }

    IEnumerator Stop()
    {
        codeController.RemoveCodes("0088");
        Manager.CodeDisplayer.currentCodes.Remove("0088");
        switcher = true;
        SuccessSound.Play();
        yield return new WaitForSeconds(2);
        audioSource.Stop();
        audioToMatch.Stop();
        AssociatedPuzzle.solved = true;
        SuccessSound.Stop();
        yield break;
    }

    void PitchGenerator()
    {
        AssociatedPuzzle.solved = false;

        float pitch = UnityEngine.Random.Range(0f, 3f);

        startingPitch = pitch;

        switcher = false;
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}