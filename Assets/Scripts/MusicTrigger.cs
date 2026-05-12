using UnityEngine;
using UnityEngine.InputSystem;

public class MusicTrigger : MonoBehaviour
{
    public MusicPlayer parentMusicPlayer;

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<MusicPlayer>(out MusicPlayer music))
            music.SetPlay(Keyboard.current.qKey.isPressed, 1);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MusicPlayer>(out MusicPlayer music))
            music.SetPlay(false, 0);
    }
}