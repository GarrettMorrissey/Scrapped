using UnityEngine;

public class FireSound : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _fireOn = null, _fireOff = null;
    private bool _fireStatus = false;

    private void OnBecameVisible()
    {
        if (_fireStatus == false)
        {
            _fireOn.Post(gameObject);
            _fireStatus = true;
        }
    }

    private void OnBecameInvisible()
    {
        if (_fireStatus == true)
        {
            _fireOff.Post(gameObject);
            _fireStatus = false;
        }
    }
}
