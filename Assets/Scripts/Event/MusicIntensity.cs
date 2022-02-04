using UnityEngine;

public class MusicIntensity : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _calm = null;
    [SerializeField] private AK.Wwise.Event _intensity = null;
    private const uint _THRESHOLD = 1;
    public static uint _enemiesOnScreen = 0;
    private static bool _isBeyondThreshold = true;

    private void Update()
    {
        if(_enemiesOnScreen >= _THRESHOLD && !_isBeyondThreshold)
        {
            _intensity.Post(gameObject);
            _isBeyondThreshold = true;
        }
        else if(_enemiesOnScreen < _THRESHOLD && _isBeyondThreshold)
        {
            _calm.Post(gameObject);
            _isBeyondThreshold = false;
        }
    }

}
