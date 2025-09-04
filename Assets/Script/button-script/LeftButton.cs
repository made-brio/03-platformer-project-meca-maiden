using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MobileInput.leftPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MobileInput.leftPressed = false;
    }
}
