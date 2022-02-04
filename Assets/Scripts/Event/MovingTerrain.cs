using UnityEngine;

public class MovingTerrain : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _maxRangeFloat = 0;
    [SerializeField] private float _minRangeFloat = 0;
    [SerializeField] private bool _isX = false;
    [SerializeField] private bool _isY = false;
    private bool _atMax = false;
    private Vector3 _maxVector;
    private Vector3 _minVector;
    private bool _isVisible = false;

    [SerializeField] private AK.Wwise.Event _movingTerrainSound = null;

    private void Start()
    {
        _maxVector = transform.position;
        _minVector = transform.position;
        DetermineTransforms();
    }

    private void FixedUpdate()
    {
        if(_atMax)
        {
            transform.position = Vector3.MoveTowards(transform.position, _minVector, _speed * Time.deltaTime);
            if (transform.position.x <= _minVector.x && transform.position.y <= _minVector.y)
            {
                if(_isVisible)
                {
                    _movingTerrainSound?.Post(gameObject);
                }
                _atMax = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _maxVector, _speed * Time.deltaTime);
            if (transform.position.x >= _maxVector.x && transform.position.y >= _maxVector.y)
            {
                if (_isVisible)
                {
                    _movingTerrainSound?.Post(gameObject);
                }
                _atMax = true;
            }
        }
    }

    //will give the two points the platform will go towards
    private void DetermineTransforms()
    {
        if(_isX)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" || collision.collider.tag == "Enemy")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Enemy")
        {
            collision.collider.transform.SetParent(null);
        }
    }

    private void OnBecameVisible()
    {
        _isVisible = true;
    }

    private void OnBecameInvisible()
    {
        _isVisible = false;
    }
}
