using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateHandle : MonoBehaviour
{
    [SerializeField] private Canvas m_Canvas;

    private Vector3? CalculateWorldToScreenPos(Vector3 worldPos)
    {
        if (m_Canvas.renderMode == RenderMode.ScreenSpaceCamera)
        {
            return m_Canvas.worldCamera.WorldToScreenPoint(worldPos);
        }
        else if (m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            Vector3 screenPos = m_Canvas.transform.InverseTransformPoint(worldPos);
            var rectTrans = m_Canvas.transform as RectTransform;
            screenPos.x += rectTrans.rect.width * 0.5f * rectTrans.localScale.x;
            screenPos.y += rectTrans.rect.height * 0.5f * rectTrans.localScale.y;
            return screenPos;
        }

        return null;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left) return;

        //Calculate the position of the current object from the lower left corner of the canvas
        Vector3? curScreenPos = CalculateWorldToScreenPos(transform.position);
        if (curScreenPos == null) return;
        //Mouse position offset
        Vector2 offset = eventData.position - (Vector2)curScreenPos.Value;
        if (offset != Vector2.zero)
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, offset);
        }
    }
}
