using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool timerActive = false;
    public float currentTime;
    public float startMinutes;
    public TextMeshProUGUI currentTimeText;

    public StopWatch stopWatch;

    // Start is called before the first frame update
    public void Start()
    {
        currentTime = startMinutes * 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime - Time.deltaTime;

            if (currentTime <= 0)
            {
                timerActive = false;
                Start();
                stopWatch.StopStopWatch();
                StopTimer();
            }
        }

        TimeSpan time = TimeSpan.FromSeconds(currentTime);

       // Debug.Log(time.Minutes.ToString() + ":" + time.Seconds.ToString());
        currentTimeText.text = time.ToString(@"mm\:ss");

    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }
}

