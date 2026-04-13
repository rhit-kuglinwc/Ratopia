using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    public MusicPlayer parentMusicPlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parentMusicPlayer.SetPlayerInRange(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            parentMusicPlayer.SetPlayerInRange(false);
        }
    }
}