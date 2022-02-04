using UnityEngine;

public class BossAttack : MonoBehaviour
{
    //for when the player comes into trigger range
    private bool _playerInSight;
    private Transform _player = null;

    //for attacking with bomb
    [SerializeField] private GameObject _shot = null;
    [SerializeField] private GameObject _shotSpawn = null;
    [SerializeField] private GameObject _anchor = null;
    [SerializeField] private float _stoppingDistance = 0;
    private float _timeBetweenShots = 0;
    [SerializeField] private float _startTimeBetweenShots = 0;
    [SerializeField] private GameObject _bossRig = null;
    [SerializeField] private float _rightFacing = -240f;
    [SerializeField] private float _leftFacing = -120f;
    private Animator _bossAnimator;
    private Vector3 _direction;
    private float _angle;
    [SerializeField] private LayerMask _wallLayer = default;

    //script reference
    private EnemyHealth _eh;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _eh = GetComponent<EnemyHealth>();
        _bossAnimator = GetComponentInChildren<Animator>();
    }

    //used if player is or not in range
    public void PlayerDetection()
    {
        if (!_eh._isDying)
        {
            if (_playerInSight == true)
            {
                AdjustAim();
                Attack_player();
            }
            AnimationDirection();
        }
    }

    //controls attack behaviour
    private void Attack_player()
    {
        if (Vector2.Distance(transform.position, _player.position) <= _stoppingDistance)
        {
            Check_shots();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerInSight = false;
        }
    }

    //handles enemy _shots
    private void Check_shots()
    {
        if (_timeBetweenShots <= 0)
        {
            Shooting();
        }
        else
        {
            _timeBetweenShots -= Time.deltaTime;
        }
    }

    private void Shooting()
    {
        Vector3 vectorToPlayer = (_player.position - _anchor.transform.position);
        float distance = vectorToPlayer.magnitude;
        Vector3 dirToPlayer = vectorToPlayer.normalized;
        Ray bombRay = new Ray(_anchor.transform.position, dirToPlayer);
        if (Physics2D.Raycast(bombRay.origin, bombRay.direction, distance, _wallLayer))
        {
            return;
        }
        _bossAnimator?.SetTrigger("Attack");
        Instantiate(_shot, _shotSpawn.transform.position, _anchor.transform.rotation);
        _timeBetweenShots = _startTimeBetweenShots;
    }

    private void AdjustAim()
    {
        _direction = _player.position - transform.position;
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        _anchor.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
    }

    //handles directions
    private void AnimationDirection()
    {
        if (_player.position.x <= transform.position.x)
        {
            _bossRig.transform.eulerAngles = new Vector3(0, _leftFacing, 0);
        }
        else
        {
            _bossRig.transform.eulerAngles = new Vector3(0, _rightFacing, 0);
        }
    }
}
