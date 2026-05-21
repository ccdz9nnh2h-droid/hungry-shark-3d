using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip eatSound;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private AudioClip waterLoopSound;

    private AudioSource audioSource;
    private AudioSource musicSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        GameObject musicObject = new GameObject("MusicSource");
        musicObject.transform.parent = transform;
        musicSource = musicObject.AddComponent<AudioSource>();
        if (waterLoopSound != null)
        {
            musicSource.clip = waterLoopSound;
            musicSource.loop = true;
            musicSource.volume = 0.3f;
            musicSource.Play();
        }
    }

    public void PlayEatSound()
    {
        if (eatSound != null)
            audioSource.PlayOneShot(eatSound, 0.7f);
    }

    public void PlayExplosionSound()
    {
        if (explosionSound != null)
            audioSource.PlayOneShot(explosionSound, 1f);
    }
}
