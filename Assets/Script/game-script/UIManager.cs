using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [Header("Panels")]
    public GameObject losePanel;
    public GameObject winPanel;


    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Call this when player loses
    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
        
        Time.timeScale = 0f; // Freeze game
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);

        Time.timeScale = 0f; // Freeze game
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene-2");
        AudioManager.Instance.PlayInGameMusic();
    }

    // Called by Exit button on either panel
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        AudioManager.Instance.PlayBGM();
        SceneManager.LoadScene("Main-Menu");
    }
}
