using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ColourButtonPuzzle : MonoBehaviour
{
    public Button[] buttons;

    //public TextMeshProUGUI textArea;

    public bool PressingGreen = false;

    public bool PressingBlack = false;

    public string code;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].GetComponent<Button>().onClick.AddListener(GreenClick);

        buttons[1].GetComponent<Button>().onClick.AddListener(BlackClick);

        //buttons[0].GetComponent<Button>().OnPointerUp.AddListener(GreenRelease);

        //buttons[1].GetComponent<Button>().OnPointerUp.AddListener(BlackRelease);


        buttons[2].GetComponent<Button>().onClick.AddListener(YellowClick);

        buttons[3].GetComponent<Button>().onClick.AddListener(BlueClick);

        buttons[4].GetComponent<Button>().onClick.AddListener(RedClick);
    }

    void GreenClick()
    {
        PressingGreen = true;
    }

    void BlackClick()
    {
        PressingBlack = true;
    }

    public void GreenRelease()
    {
        PressingGreen = false;
        Erase();
    }

    public void BlackRelease()
    {
        PressingBlack = false;
        Erase();
    }

    void YellowClick()
    {
        code += "y";
    }

    void BlueClick()
    {
        code += "b";
    }

    void RedClick()
    {
        code += "r";
    }

    void Erase()
    {
        code = "";
    }

    void Update()
    {
        CheckAnswer();
    }

    public void CheckAnswer()
    {
        if (code == "ybr" && PressingGreen)
            Debug.Log("yes");
    }

}
