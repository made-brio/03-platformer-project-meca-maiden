using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Vector2 targetX;
    public float moveSpeed = 2f;

    private Vector2 startPosition;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        // Gerak ke kiri sampai targetX
        transform.localScale = originalScale; // Hadap kiri
        while (transform.position.x > targetX.x)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            yield return null;
        }

        // Tunggu 2 detik
        yield return new WaitForSeconds(2f);

        // Balik arah dengan skala x * -1 (hadap kanan)
        Vector3 flippedScale = new Vector3(originalScale.x * -1f, originalScale.y, originalScale.z);
        transform.localScale = flippedScale;
        while (transform.position.x < startPosition.x)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            yield return null;
        }

        // Ulangi gerakan
        StartCoroutine(MoveRoutine());
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        StartCoroutine(HandlePlayerCollision(other.gameObject));
    //    }
    //}

    //private IEnumerator HandlePlayerCollision(GameObject player)
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    UIManager.Instance.ShowLosePanel();
    //}
}
