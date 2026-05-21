using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    // Sound stuff
    private AudioSource audioSource;

    [Header("Fade Settings")]
    public float fadeSpeed = 2f;

    private float targetVolume;

    private bool play = false;

    // Color stuff
     public Color smellColor = new(1f, 0.55f, 0.15f, 1f);
    public float smellRange = 12f;
    public float smellStrength = 1f;

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

    public void SetPlay(bool to){
        play = to;
    }
}