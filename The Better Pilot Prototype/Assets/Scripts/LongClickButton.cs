using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

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
			//Debug.Log("OnPointerDown");

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
			//Debug.Log("OnPointerUp");
		}
	}

	private void Update()
	{
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

}