using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && NoCoinsLeft())
        {
            StartCoroutine(HandlePlayerCollision(other.gameObject));
        }
    }

    private bool NoCoinsLeft()
    {
        // Find all objects with CoinScript in the scene
        CoinScript[] coins = FindObjectsOfType<CoinScript>();
        // If the length is 0, then there are no coins left
        return coins.Length == 0;
    }

    private IEnumerator HandlePlayerCollision(GameObject player)
    {
        AudioManager.Instance.PlayWinMusic();
        yield return new WaitForSeconds(0.5f);
        UIManager.Instance.ShowWinPanel();
       
    }
}
