using UnityEngine;
using System.Collections;

public class BossFlyPattern : MonoBehaviour
{
    //movement variables
    private float _speed = 1f;
    private float _maxRangeFloat = 0;
    private float _minRangeFloat = 0;
    [SerializeField] private bool _isX = false;
    [SerializeField] private bool _isY = false;
    private bool _atMax = false;
    [SerializeField] private float _flyTimeLimit = 5f;

    private Vector3 _maxVector;
    private Vector3 _minVector;

    //control bool
    private bool _flying;

    public void NewTransforms()
    {
        _maxVector = transform.position;
        _minVector = transform.position;
        DetermineTransforms();
    }

    private void Start()
    {
        StartCoroutine("FlyDirection");
    }

    private void FixedUpdate()
    {
        if (_flying)
        {
            StageMovement();
        }
    }

    //will give the two points the boss will go towards
    private void DetermineTransforms()
    {
        if (_isX)
        {
            _maxVector.x += _maxRangeFloat;
            _minVector.x -= _minRangeFloat;
        }

        if (_isY)
        {
            _maxVector.y += _maxRangeFloat;
            _minVector.y -= _minRangeFloat;
        }
    }

    //controls if the boss is flying
    public void FlyPattern(bool _input)
    {
        _flying = _input;
    }

    //boss movement while in this stage
    private void StageMovement()
    {
        if (_atMax)
        {
            transform.position = Vector3.MoveTowards(transform.position, _minVector, _speed * Time.deltaTime);
            if (transform.position.x <= _minVector.x && transform.position.y <= _minVector.y)
            {
                _atMax = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _maxVector, _speed * Time.deltaTime);
            if (transform.position.x >= _maxVector.x && transform.position.y >= _maxVector.y)
            {
                _atMax = true;
            }
        }
    }

    //called by the stages to influence how it flies
    public void SetValues(float _stageSpeed, float _stageMax, float _stageMin)
    {
        _speed = _stageSpeed;
        _maxRangeFloat = _stageMax;
        _minRangeFloat = _stageMin;
    }

    private void ChangeDirection(bool _boolValue)
    {
        if(_boolValue)
        {
            _boolValue = false;
        }
        else
        {
            _boolValue = true;
        }
    }

    IEnumerator FlyDirection()
    {
        yield return new WaitForSeconds(_flyTimeLimit);
        ChangeDirection(_isX);
        ChangeDirection(_isY);
    }

    public void DirectionRoutineSwitch(bool _control)
    {
        if(_control)
        {
            StartCoroutine("FlyDirection");
        }
        else
        {
            StopCoroutine("FlyDirection");
        }
    }
}
