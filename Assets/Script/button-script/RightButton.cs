using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MobileInput.rightPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MobileInput.rightPressed = false;
    }
}
