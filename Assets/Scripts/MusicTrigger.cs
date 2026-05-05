using UnityEngine;
using UnityEngine.InputSystem;

public class MusicTrigger : MonoBehaviour
{
    public float volumeMult = 1;

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<MusicPlayer>(out MusicPlayer music))
            music.SetPlay(Keyboard.current.qKey.isPressed, volumeMult);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MusicPlayer>(out MusicPlayer music))
            music.SetPlay(false, 0);
    }
}