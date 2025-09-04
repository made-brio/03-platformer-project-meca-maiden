using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int coinCount = 0;
    public int lifeCount = 3;

    public TMP_Text coinText;

    public BatteryCountController batteryUI;


    private void Awake()
    {
        Reset();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (coinCount>=10&&FindAnyObjectByType<PlayerScript>().gameObject.CompareTag("end"))
        {
            UIManager.Instance.ShowWinPanel();
        }
    }
    public void AddLife(int value)
    {
        lifeCount += value;
        UpdateUI();
    }

    public void LoseLife(int value)
    {
        lifeCount -= value;
        UpdateUI();
        if (lifeCount <= 0)
        {
            lifeCount = 0;
            UIManager.Instance.ShowLosePanel();
            AudioManager.Instance.PlayGameOverMusic();
        }
        
    }

    public void AddCoin(int value)
    {
        coinCount+=value;
        UpdateUI();
    }
    public void Reset()
    {
        Time.timeScale = 1f;
        lifeCount = 3;
        coinCount = 0;
        UpdateUI();
    }
    public void UpdateUI()
    {
        batteryUI.SetBatteryCount(coinCount);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FindUIWithDelay());
    }

    private System.Collections.IEnumerator FindUIWithDelay()
    {
        yield return null; 
        coinText = GameObject.FindWithTag("CoinText")?.GetComponent<TMP_Text>();
        UpdateUI();
    }

    

}


