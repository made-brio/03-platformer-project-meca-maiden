using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnExitButtonPressed()
    {
        // Quits the application
        Application.Quit();

        // Debug only: Works in the Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
