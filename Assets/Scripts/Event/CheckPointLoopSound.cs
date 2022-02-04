using UnityEngine;

public class CheckPointLoopSound : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _loopOn = null, _loopOff = null;
    public bool _control = false;

    private void OnBecameVisible()
    {
        if(_control)
        {
            _loopOn.Post(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        if (_control)
        {
            _loopOff.Post(gameObject);
        }
    }
}
