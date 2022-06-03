using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameLoader : MonoBehaviour
{
    public void QuitApp()
    {
        Application.Quit();
    }

    public void ShowSettings()
    {
        Application.LoadLevel("MainMenu");
    }

    public void ShowInstructions()
    {
        Application.LoadLevel("MainMenu");
    }

    public void LoadGame()
    {
        
    }
}

