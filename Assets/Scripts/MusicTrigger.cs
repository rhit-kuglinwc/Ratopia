using UnityEngine;
using UnityEngine.InputSystem;

public class MusicTrigger : MonoBehaviour
{
    public MusicPlayer parentMusicPlayer;

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<MusicPlayer>(out MusicPlayer music))
            music.setPlay(Keyboard.current.qKey.isPressed);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<MusicPlayer>(out MusicPlayer music))
            music.setPlay(false);
    }
}