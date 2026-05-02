using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

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

    void Play()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
        HandleAudio();
    }

    void Stop()
    {
        audioSource.Pause();
    }

    void HandleAudio()
    {
        audioSource.volume = Mathf.MoveTowards(
            audioSource.volume,
            targetVolume,
            fadeSpeed * Time.deltaTime
        );

        if (audioSource.volume <= 0.01f && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
}