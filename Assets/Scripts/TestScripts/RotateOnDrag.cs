using UnityEngine;
using UnityEngine.EventSystems;

public class RotateOnDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private bool isDragging = false;
    private Vector2 lastMousePosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        lastMousePosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector2 currentMousePosition = eventData.position;
            Vector2 mouseDelta = currentMousePosition - lastMousePosition;

            float angle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            lastMousePosition = currentMousePosition;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
