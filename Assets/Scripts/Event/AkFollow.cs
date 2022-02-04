using UnityEngine;

public class AkFollow : MonoBehaviour
{
    private Transform _target = null;
    [SerializeField] private string _playerTag = "Player";

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag(_playerTag)?.transform;
    }

    private void Update()
    {
        if (_target == null)
        {
            _target = GameObject.FindGameObjectWithTag(_playerTag)?.transform;
        }
        if (_target != null)
        {
            transform.position = new Vector3 (_target.position.x, _target.position.y + 0.65f, _target.position.z);
        }
    }
}
