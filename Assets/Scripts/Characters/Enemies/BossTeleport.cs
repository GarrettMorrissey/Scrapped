using UnityEngine;

public class BossTeleport : MonoBehaviour
{
    [SerializeField] private Transform[] _teleportSpots = null;
    [SerializeField] private GameObject _portal = null;
    private int _teleportIndex = 0;

    public void CallTeleport()
    {
        Instantiate(_portal, transform.position, Quaternion.identity);
        if (_teleportIndex >= _teleportSpots.Length)
        {
            _teleportIndex = 0;
        }
        transform.position = _teleportSpots[_teleportIndex].position;
        _teleportIndex++;
        Instantiate(_portal, transform.position, Quaternion.identity);
    }
}
