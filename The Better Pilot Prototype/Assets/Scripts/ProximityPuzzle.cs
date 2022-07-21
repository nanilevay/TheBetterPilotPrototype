using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProximityPuzzle : MonoBehaviour
{
    public ProximityDetector Sensor;

    public Image Led;

    public PuzzlePiece AssociatedPuzzle;

    public GameManager Manager;

    public Coroutine coroutine;

    public bool Once = true;

    public CodeController codeController;

    public SensorListener SensorValue;

    public int rnd;

    public TextMeshProUGUI DebugText;

    public AudioSource AudioToPlay;

    // Update is called once per frame
    void Update()
    {
        DebugText.text = SensorValue.sensor.ToString();

        if (Manager.CodeDisplayer.currentCodes.Contains("2922"))
        {

            //if (SensorValue.sensor <= rnd + 2 && SensorValue.sensor >= rnd - 2)
            //{
            //    //StartCoroutine(SoundPlayer());
            //}

            //else
            //{
            //    StartCoroutine(SoundStopper());
            //}


            if (/*Sensor.ProximityDetected &&*/ Once && Manager.CodeDisplayer.currentCodes.Contains("2922"))
            {
                Once = false;
                StartCoroutine(DistanceMaker());
            }

            if (AssociatedPuzzle.solved)
            {
                Led.color = Color.green;
                Once = true;
            }
        }

        else
        {
            Once = true;
            AssociatedPuzzle.solved = false;
        }

        //if (SensorValue.sensor >= rnd + 4 || SensorValue.sensor <= rnd - 4)
        //{
        //    //StartCoroutine(SoundStopper());
        //}
    }

    IEnumerator DistanceMaker()
    {
        rnd = UnityEngine.Random.Range(5, 15);

        Debug.Log(rnd);

        StartCoroutine(FinishPuzzle());

        yield break;
    }

    IEnumerator SoundPlayer()
    {
        if(!AudioToPlay.isPlaying)
            AudioToPlay.Play();

        yield break;
    }

    IEnumerator SoundStopper()
    {
        if (AudioToPlay.isPlaying)
            AudioToPlay.Stop();

        yield break;
    }

    IEnumerator FinishPuzzle()
    {
        //while (SensorValue.sensor > rnd + 4 || SensorValue.sensor < rnd - 4)
        //{
        Led.color = Color.blue;
        yield return new WaitForSeconds(1f);
        Led.color = Color.black;
        yield return new WaitForSeconds(1f);
        Led.color = Color.blue;
        yield return new WaitForSeconds(1f);
        Led.color = Color.black;
        yield return new WaitForSeconds(1f);
        Led.color = Color.blue;
        yield return new WaitForSeconds(1f);

        var tempColor = Led.color;
        tempColor.a = map(SensorValue.sensor, 0, 20, 0, 1);
        Led.color = tempColor;

        if (SensorValue.sensor <= rnd + 4 && SensorValue.sensor >= rnd - 4)
            {
                codeController.RemoveCodes("2922");
                Manager.CodeDisplayer.currentCodes.Remove("2922");
                AssociatedPuzzle.solved = true;
                Once = true;
                Led.color = Color.green;
                StartCoroutine(SoundStopper());
                yield break;
            }
        //}

        Led.color = Color.green;
        Once = true;
        yield break;
       
    }

    public static float map(float value, float leftMin, float leftMax, float rightMin, float rightMax)
    {
        return rightMin + (value - leftMin) * (rightMax - rightMin) / (leftMax - leftMin);
    }
}