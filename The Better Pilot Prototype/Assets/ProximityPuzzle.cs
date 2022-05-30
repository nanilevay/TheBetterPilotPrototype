using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Sensor.ProximityDetected && Once && !AssociatedPuzzle.solved)
        {
            Once = false;
            coroutine = StartCoroutine(FinishPuzzle());
        }

        if(AssociatedPuzzle.solved)
        {
            Led.color = Color.green;
            Once = true;
        }
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
            yield return new WaitForSeconds(1f);
            Led.color = Color.blue;
            yield return new WaitForSeconds(1f);
            Led.color = Color.black;
            yield return new WaitForSeconds(1f);

            if(Sensor.ProximityDetected)
            {
                AssociatedPuzzle.solved = true;
                Once = true;
                Led.color = Color.green;
                yield break;
            }
        }

        Led.color = Color.green;
        Once = true;
        yield break;
       
    }
}
