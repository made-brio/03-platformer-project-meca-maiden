using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MobileInput.jumpPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MobileInput.jumpPressed = false;
    }
}
