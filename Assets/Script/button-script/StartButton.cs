using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Replace with your in-game scene name
    public string sceneName = "GameScene";

    public void OnStartButtonPressed()
    {

        AudioManager.Instance.PlayInGameMusic();
        SceneManager.LoadScene(sceneName);
    }
}
