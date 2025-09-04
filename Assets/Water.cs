using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandlePlayerCollision(other.gameObject));
           
        }
    }

    private IEnumerator HandlePlayerCollision(GameObject player)
    {
        // Optional: disable player controls or effects here
        yield return new WaitForSeconds(1f);

        // Show win panel via GameManager
        UIManager.Instance.ShowLosePanel();
    }
}
