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
        DebugText.text = SensorValue.distanceVal.ToString();

        if (Manager.CodeDisplayer.currentCodes.Contains("2922"))
        {

            if (SensorValue.distanceVal <= rnd + 2 && SensorValue.distanceVal >= rnd - 2)
            {
                StartCoroutine(SoundPlayer());
            }

            else
            {
                StartCoroutine(SoundStopper());
            }


            if (Sensor.ProximityDetected && Once && !AssociatedPuzzle.solved)
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

        if (SensorValue.distanceVal >= rnd + 2 || SensorValue.distanceVal <= rnd - 2)
        {
            StartCoroutine(SoundStopper());
        }
    }

    IEnumerator DistanceMaker()
    {
        rnd = UnityEngine.Random.Range(0,15);

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
        while (Sensor.ProximityDetected)
        {
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
            Led.color = Color.black;

            if (SensorValue.distanceVal <= rnd + 2 && SensorValue.distanceVal >= rnd - 2)
            {
                codeController.RemoveCodes("2922");
                Manager.CodeDisplayer.currentCodes.Remove("2922");
                AssociatedPuzzle.solved = true;
                Once = true;
                Led.color = Color.green;
                StartCoroutine(SoundStopper());
                yield break;
            }
        }

        Led.color = Color.green;
        Once = true;
        yield break;
       
    }
}