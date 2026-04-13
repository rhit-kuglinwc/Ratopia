using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private bool playerInRange = false;
    private bool isHolding = false;

    [Header("Fade Settings")]
    public float fadeSpeed = 2f;

    private float targetVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1f;

        targetVolume = 0f;
        audioSource.volume = 0f;
    }

    void Update()
    {
        HandleInput();
        HandleAudio();
    }

    void HandleInput()
    {
        if (Keyboard.current == null) return;

        isHolding = playerInRange && Keyboard.current.qKey.isPressed;
        targetVolume = isHolding ? 1f : 0f;

        if (isHolding && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void HandleAudio()
    {
        audioSource.volume = Mathf.MoveTowards(
            audioSource.volume,
            targetVolume,
            fadeSpeed * Time.deltaTime
        );

        if (audioSource.volume <= 0.01f && !isHolding && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    // 👇 Called by child trigger
    public void SetPlayerInRange(bool value)
    {
        playerInRange = value;
    }
}