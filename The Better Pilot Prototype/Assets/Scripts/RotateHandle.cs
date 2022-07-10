using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RotateHandle : MonoBehaviour, IDragHandler
{
    public bool active = true;
    [SerializeField] private Canvas m_Canvas;
    public TextMeshProUGUI textDisplay;

    public bool IsMoving = false;

    public bool SendValue;

    float currentRot;

    public bool Once = true;

    public AudioSource AudioToPlay;

    public SensorListener SensorValues;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, SensorValues.d1);
    }
    IEnumerator PlaySound()
    {
        AudioToPlay.Play();
        yield break;
    }

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
        if (active)
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
               
                IsMoving = true;

                if (currentRot - 360 >= 180)
                    SendValue = true;

                else
                    SendValue = false;
            }
        }   
    }

    public void Update()
    {
        if (IsMoving && !AudioToPlay.isPlaying)
        {
            StartCoroutine(PlaySound());
        }

        if (!IsMoving)
        {
            AudioToPlay.Stop();
        }

        currentRot = gameObject.transform.localEulerAngles.z;

        if (Input.GetMouseButtonUp(0))
        {
            IsMoving = false;
        }

        if (active)
            textDisplay.text = Mathf.Round(gameObject.transform.localEulerAngles.z).ToString() + "º";

        else
        {
            textDisplay.text = "Component OFF";
        }
    }

    public void RotateObject(float valueToRotate)
    {
        transform.rotation = Quaternion.Euler(0, 0, valueToRotate * 360 * 2);
        Debug.Log(valueToRotate);
    }


    public void PhysicalRotator()
    { 
        transform.rotation = Quaternion.Euler(0, 0, SensorValues.d1);
    }
}