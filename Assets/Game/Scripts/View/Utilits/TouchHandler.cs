using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TouchHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsTouched { get; private set; }
    public Vector2 TouchPosition { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsTouched = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsTouched = false;
    }

    private void Update()
    {
        if (!IsTouched)
            return;

        TouchPosition = Touchscreen.current.primaryTouch.position.ReadValue(); // Отримуємо позицію пальця
    }
}