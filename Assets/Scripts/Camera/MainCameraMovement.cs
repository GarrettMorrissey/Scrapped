using UnityEngine;
using System.Collections;

public class MainCameraMovement : MonoBehaviour
{
    //normal values
    private GameObject _player = null;
    public float _yOffset = 1f;
    public float _zOffset = 20f;
    public float _fovVariable = 60f;
    private Vector3 _cameraNormalPosition;

    //shakevalues
    private bool _isShaking = false;
    private Vector3 _shakePosition;
    [SerializeField] float _lerpTime = 0.25f;
    private float _currentLerpTime = 0;
    [SerializeField] float _shakeAmount = 1f;
    private float _percentage;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        if (_player != null)
        {
            NormalCameraMovement();
            if(_isShaking)
            {
                transform.position = _shakePosition;
            }
            else
            {
                transform.position = _cameraNormalPosition;
            }
            Camera.main.fieldOfView = _fovVariable;
        }
    }

    private void NormalCameraMovement()
    {
        _cameraNormalPosition = new Vector3(_player.transform.position.x,
            _player.transform.position.y + _yOffset,
            _player.transform.position.z - _zOffset);
    }

    public void StartShake()
    {
        _isShaking = true;
        StartCoroutine("CameraShake");
    }

    private void StopShake()
    {
        _isShaking = false;
        StopCoroutine("CameraShake");
    }

    private IEnumerator CameraShake()
    {
        _shakePosition = _cameraNormalPosition;
        _shakePosition.x -= 0.5f;
        while(_currentLerpTime < _lerpTime)
        {
            _currentLerpTime += Time.deltaTime;
            _percentage = _currentLerpTime / _lerpTime;
            _shakePosition.x += Mathf.Sin(_currentLerpTime * _shakeAmount) * _percentage;
            yield return null;
        }
        yield return null;
        StopShake();
    }
}
