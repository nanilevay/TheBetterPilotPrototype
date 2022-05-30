using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

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

    void Awake()
    {
       // PitchGenerator();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the AudioSource from the GameObject
       // audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
       // audioSource.pitch = startingPitch;
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
            switcher = true;
            audioSource.Stop();
        }
    }

    IEnumerator Stop()
    {
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

        //Debug.Log(startingPitch.ToString());

        switcher = false;
    }

    //void OnSliderWasChanged()
    //{
    //    audioToMatch.Play();
    //}

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
