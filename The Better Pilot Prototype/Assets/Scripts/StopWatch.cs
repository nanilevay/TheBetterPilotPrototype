using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StopWatch : MonoBehaviour
{
    public bool stopWatchActive = false;
    public float currentTime;
    public TextMeshProUGUI currentTimeText;

    public GameObject GameOver;

    public TextMeshProUGUI FinalScore;

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

        if(GameOver.activeSelf)
        {
            //FinalScore.text = time.ToString(@"mm\:ss");
            GamePrefs.LastTimer = time.ToString(@"mm\:ss");
            SceneManager.LoadScene(3);
        }

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