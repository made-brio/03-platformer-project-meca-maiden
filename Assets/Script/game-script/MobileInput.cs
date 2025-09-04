using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static bool leftPressed = false;
    public static bool rightPressed = false;
    public static bool jumpPressed = false;

    public void OnLeftDown() => leftPressed = true;
    public void OnLeftUp() => leftPressed = false;

    public void OnRightDown() => rightPressed = true;
    public void OnRightUp() => rightPressed = false;

    public void OnJumpDown() => jumpPressed = true;
    public void OnJumpUp() => jumpPressed = false;
}
