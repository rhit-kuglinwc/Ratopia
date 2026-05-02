using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Fade Settings")]
    public float fadeSpeed = 2f;

    private float targetVolume;

    private bool play = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 1f;

        targetVolume = 0f;
        audioSource.volume = 0f;
    }

    void Update(){
        if(play){
            targetVolume = 1f;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }else{
            targetVolume = 0f;
            if(audioSource.volume <= 0.01f)
                audioSource.Pause();
        }
        audioSource.volume = Mathf.MoveTowards(
            audioSource.volume,
            targetVolume,
            fadeSpeed * Time.deltaTime
        );
    }

    public void setPlay(bool to){
        play = to;
    }
}