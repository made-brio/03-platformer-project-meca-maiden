using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public static CoinSpawner Instance;

    public GameObject coinPrefab;
    public int startingCoins = 5;
    public float minX = -10f;
    public float maxX = 10f;
    public float raycastStartY = 5f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        SpawnCoins(startingCoins);
    }

    public void SpawnCoins(int coin)
    {
        for (int i = 0; i < coin;)
        {
            float randomX = Random.Range(minX, maxX);
            Vector2 origin = new Vector2(randomX, raycastStartY);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));

            if (hit.collider != null)
            {
                i++;
                Vector3 spawnPos = new Vector3(randomX, hit.point.y + 1.2f, 0f);
                Instantiate(coinPrefab, spawnPos, Quaternion.identity);

            }
        }
    }
}
