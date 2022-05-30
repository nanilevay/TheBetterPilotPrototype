using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class HueSlider : MonoBehaviour
{ 
    public TextMeshProUGUI textDisplay;
    public float SliderValue;

    public Slider mainSlider;

    public GameManager Manager;

    public PuzzlePiece PuzzleToSolve;

    public AudioSource SuccessSound;

    // Drag & drop handle
    public Image handle;

    public void Start()
    {
        mainSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        if (!PuzzleToSolve.solved)
        {
            handle.color = Color.HSVToRGB(mainSlider.value, 1, 1);

            if (mainSlider.value * 100 >= 73 && mainSlider.value * 100 <= 82 && Manager.SerialThree && !Manager.SerialEven)
            {
                PuzzleToSolve.solved = true;
                StartCoroutine(Success());
            }

            if (mainSlider.value * 100 >= 50 && mainSlider.value * 100 <= 60 && Manager.SerialThree && Manager.SerialEven)
            {
                PuzzleToSolve.solved = true;
                StartCoroutine(Success());
            }

            if (mainSlider.value * 100 >= 14 && mainSlider.value * 100 <= 34 && !Manager.SerialThree && !Manager.SerialEven)
            {
                PuzzleToSolve.solved = true;
                StartCoroutine(Success());
            }


            if (mainSlider.value * 100 >= 83 && mainSlider.value * 100 <= 98 && !Manager.SerialThree && Manager.SerialEven)
            {
                PuzzleToSolve.solved = true;
                StartCoroutine(Success());
            }
        }
    }

    IEnumerator Success()
    {
        SuccessSound.Play();
        yield return new WaitForSeconds(2);
        SuccessSound.Stop();
        yield break;
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}
