using UnityEngine;

public class LifeUIController : MonoBehaviour
{
    public Transform lifeContainer; 
    private int totalLives;

    private void Start()
    {
        totalLives = lifeContainer.childCount;
        UpdateLifeUI(GameManager.Instance.lifeCount);
    }

    // panggil ini saat nyawa berkurang
    public void UpdateLifeUI(int currentLives)
    {
        // deactivate heart jika nyawa sudah habis
        for (int i = 0; i < lifeContainer.childCount; i++)
        {
            if (i < currentLives)
                lifeContainer.GetChild(i).gameObject.SetActive(true);
            else
                lifeContainer.GetChild(i).gameObject.SetActive(false);
        }
    }
}
