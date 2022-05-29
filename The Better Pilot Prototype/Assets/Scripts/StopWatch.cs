using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class StopWatch : MonoBehaviour
{
    public bool stopWatchActive = false;
    public float currentTime;
    public TextMeshProUGUI currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive)
        {
            currentTime = currentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
    
        currentTimeText.text = time.ToString(@"mm\:ss");

    }

    public void StartStopWatch()
    {
        stopWatchActive = true;
    }

    public void StopStopWatch()
    {
        stopWatchActive = false;
    }
}

