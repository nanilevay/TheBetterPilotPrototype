using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI TimerDisplay;

    public TextMeshProUGUI LastPlayerName;

    public TMP_InputField PlayerName;

    public GameObject ScoreSaver;

    // Update is called once per frame
    void Start()
    {
        TimerDisplay.text = GamePrefs.LastTimer.ToString();
        LastPlayerName.text = GamePrefs.LastName;
    }

    // Update is called once per frame
    void Update()
    {
        LastPlayerName.text = PlayerName.text;
    }

    public void ShowScoreSaver()
    {
        if(!ScoreSaver.activeSelf)
            ScoreSaver.SetActive(true);

        else
            ScoreSaver.SetActive(false);
    }

    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void SaveScore()
    {
        GamePrefs.LastTimer = TimerDisplay.text;
        GamePrefs.LastName = PlayerName.text;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}