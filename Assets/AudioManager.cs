using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource inGameSource;
    public AudioSource winConditionSource;
    public AudioSource gameOverSource;
    public AudioSource sfxSource;

    public AudioClip collectSFX;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM();
    }

    private void StopAllMusic()
    {
        if (bgmSource != null) bgmSource.Stop();
        if (inGameSource != null) inGameSource.Stop();       
    }

    public void PlayBGM()
    {
        StopAllMusic();
        if (bgmSource != null)
        {
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlayInGameMusic()
    {
        StopAllMusic();
        if (inGameSource != null)
        {
            inGameSource.loop = true;
            inGameSource.Play();
        }
    }

    public void PlayWinMusic()
    {
       
            winConditionSource.loop = false;
            winConditionSource.Play();
        
    }

    public void PlayGameOverMusic()
    {
       
            gameOverSource.loop = false;
            gameOverSource.Play();
    }

    public void PlayCollectSFX()
    {
        if (collectSFX != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(collectSFX);
        }
    }
}
