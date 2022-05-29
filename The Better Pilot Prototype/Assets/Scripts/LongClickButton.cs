using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public bool pointerDown;
	public float pointerDownTimer;

	[SerializeField]
	public float requiredHoldTime;

	public UnityEvent onLongClick;

	[SerializeField]
	public Image fillImage;

	public PuzzlePiece puzzle;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (puzzle.active)
		{
			pointerDown = true;
			Debug.Log("OnPointerDown");
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (puzzle.active)
		{
			Reset();
			Debug.Log("OnPointerUp");
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
	}

	public void Reset()
	{
		pointerDown = false;
		pointerDownTimer = 0;
		fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
	}

}