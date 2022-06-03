using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject PauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            PauseMenu.SetActive(true);
            gameIsPaused = false;
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            gameIsPaused = true;
        }
    }

}