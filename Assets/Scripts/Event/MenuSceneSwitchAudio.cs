using UnityEngine;

public class MenuSceneSwitchAudio : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _stopTune = null;

    public void StopSound()
    {
        _stopTune.Post(gameObject);
    }
}
