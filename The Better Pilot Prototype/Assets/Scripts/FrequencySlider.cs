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

    void Awake()
    {
        PitchGenerator();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the AudioSource from the GameObject
        audioSource = GetComponent<AudioSource>();

        //Initialize the pitch
        audioSource.pitch = startingPitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (Detector.ProximityDetected)
            ProximityCheck = true;
        else
            ProximityCheck = false;

        SliderValue = map(mainSlider.value, 0f,1f,0f,3f);

        audioToMatch.pitch = SliderValue;

        if (ProximityCheck && !audioToMatch.isPlaying)
            audioToMatch.Play();
        if (!ProximityCheck)
            audioToMatch.Stop();

        if (ProximityCheck && Mathf.Round(SliderValue * 10.0f) * 0.1f == Mathf.Round(startingPitch * 10.0f) * 0.1f && Detector.ProximityDetected)
            AssociatedPuzzle.solved = true;

       // Debug.Log(Mathf.Round(SliderValue * 10.0f) * 0.1f);
    }

    void PitchGenerator()
    {
        float pitch = UnityEngine.Random.Range(0f, 3f);

        startingPitch = pitch;

        //Debug.Log(startingPitch.ToString());
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
