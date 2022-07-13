using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
	public bool pointerDown;
	public float pointerDownTimer;

	[SerializeField]
	public float requiredHoldTime;

	public UnityEvent onLongClick;

	[SerializeField]
	public Image fillImage;

	public PuzzlePiece puzzle;

	public int tap;

	public bool DoubleTap = false;

	public bool hold = false;

    public Image HoldImg;

    public Color ImgColor;

    public SensorListener ButtonColour;

    public bool Once = true;

    public string ID;

    public int ArduinoPress = 1;

    void Start()
    {
        ImgColor = HoldImg.color;
        Once = true;
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		tap = eventData.clickCount;

		if (tap == 2)
		{
			
			DoubleTap = true;
		}

		else
        {
			DoubleTap = false;
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (puzzle.active)
		{
			pointerDown = true;

			if (Input.GetKey(KeyCode.LeftControl))
			{
				hold = true;
			}
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (puzzle.active)
		{
			Reset();
		}
	}

	private void Update()
	{
        if(tap == 1)
        {
            StartCoroutine(DoubleTapChecker());
        }

        if (ID == "rm")
        {
            ArduinoPress = ButtonColour.redMorse;
        }

        if (ID == "bm")
        {
            ArduinoPress = ButtonColour.blckMorse;
        }

        if (ID == "g")
        {
            ArduinoPress = ButtonColour.greenButton;
        }

        if (ID == "z")
        {
            ArduinoPress = ButtonColour.blckButton;
        }

        if (ID == "b")
        {
            ArduinoPress = ButtonColour.blueButton;
        }

        if (ID == "y")
        {
            ArduinoPress = ButtonColour.yellowButton;
        }

        if (ID == "r")
        {
            ArduinoPress = ButtonColour.redButton;
        }


        if (ArduinoPress == 0 && Once)
        {
            var go = this.gameObject;
            var ped = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(go, ped, ExecuteEvents.pointerClickHandler);
            ExecuteEvents.Execute(go, ped, ExecuteEvents.submitHandler);
            Once = false;
            tap += 1;

            StartCoroutine(CheckLongPress());

        }

        else if (ArduinoPress == 1 && !Once)
        {
            var go = this.gameObject;
            var ped = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(go, ped, ExecuteEvents.pointerUpHandler);
            ExecuteEvents.Execute(go, ped, ExecuteEvents.submitHandler);
            Once = true;
            tap -= 1;
            hold = false;
        }

        if (hold)
        {
            HoldImg.color = Color.cyan;
        }

        else
        {
            HoldImg.color = ImgColor;
        }

        if (pointerDown)
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer >= requiredHoldTime)
			{
				if (onLongClick != null)
					onLongClick.Invoke();

				Reset();
			}
			fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
		}

		if (Input.GetKeyUp(KeyCode.LeftControl) && hold)
		{
			hold = false;
		}
	}

	public void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
		fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
	}

    public IEnumerator DoubleTapChecker()
    {
        yield return new WaitForSeconds(1);
        if (tap == 1)
            tap += 1;
    }

    public IEnumerator CheckLongPress()
    {
        yield return new WaitForSeconds(1);
        if (ArduinoPress == 0)
            hold = true;
    }
}