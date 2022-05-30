using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class SwitchesPuzzle : MonoBehaviour
{

    public ServoRotation Servo;

    public Toggle SwitchOne;

    public Toggle SwitchTwo;

    public PuzzlePiece associatedPuzzle;

    public bool Once = true;

    public Image Led;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!associatedPuzzle.solved && Once)
        {
            StartCoroutine(Checker());
            Once = false;
        }
    }

    public IEnumerator Checker()
    {
        while (Mathf.Round(Servo.value) >= 90)
        {
            Led.color = Color.blue;
            yield return new WaitForSeconds(1f);
            Led.color = Color.black;
            yield return new WaitForSeconds(1f);
            Led.color = Color.blue;
            yield return new WaitForSeconds(1f);
            Led.color = Color.black;

            if (SwitchOne.isOn && SwitchTwo.isOn)
            {
                associatedPuzzle.solved = true;
                Once = true;
                Led.color = Color.green;
                Servo.increasing = false;
                yield break;
            }
        }

        while (Mathf.Round(Servo.value) <= 90)
        {
            Led.color = Color.blue;
            yield return new WaitForSeconds(1f);
            Led.color = Color.black;
            yield return new WaitForSeconds(1f);
            Led.color = Color.blue;
            yield return new WaitForSeconds(1f);
            Led.color = Color.black;

            if (!SwitchOne.isOn && !SwitchTwo.isOn)
            {
                associatedPuzzle.solved = true;
                Once = true;
                Led.color = Color.green;
                Servo.increasing = true;
                yield break;
            }
        }
        Once = true;
        yield break;
    }
}
