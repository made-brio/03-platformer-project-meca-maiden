using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddCoin(1);
            AudioManager.Instance.PlayCollectSFX();
            Destroy(gameObject);
        }
    }
}
