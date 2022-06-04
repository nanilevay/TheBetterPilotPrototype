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

    public Animator anim;

    public GameObject FadeObj;

    public GameObject FadeOutObj;

    public Animator FadeOutAnim;

    public GameObject Settings;

    public GameObject Instructions;
    void Awake()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        anim.SetBool("start", true);
        yield return new WaitForSeconds(1);
        FadeObj.SetActive(false);

        yield break;
    }

    public void FadeOutStart()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        FadeOutObj.SetActive(true);
        FadeOutAnim.SetBool("start", true);
        yield return new WaitForSeconds(2);   
        LoadGame();
        yield break;
    }
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
        Application.LoadLevel(1);
    }

    public void ToggleSettings()
    {
        if (!Settings.activeSelf)
            Settings.SetActive(true);
        else
            Settings.SetActive(false);
    }

    public void ToggleInstructions()
    {
        if(!Instructions.activeSelf)
            Instructions.SetActive(true);
        else
            Instructions.SetActive(false);
    }
}

