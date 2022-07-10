using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPresses : MonoBehaviour, IPointerClickHandler
{
    int tap;

    public bool DoubleTap = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        tap = eventData.clickCount;

        if (tap == 2)
        {
            Debug.Log("oof");
            DoubleTap = true;
        }

    }
}