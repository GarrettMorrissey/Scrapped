using UnityEngine;

public class SkipAudio : MonoBehaviour
{

    [SerializeField] private AK.Wwise.Event _stopStartingTune = null;

    public void SkipCinematicSound()
    {
        _stopStartingTune.Post(gameObject);
    }
}
