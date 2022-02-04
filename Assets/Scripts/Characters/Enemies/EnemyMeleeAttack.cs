using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    //for when the player comes into trigger range
    private bool _playerInSight;
    private Transform _player = null;

    //for attacking 
    [SerializeField] private float _stoppingDistance = 0;
    private float _timeBetweenAttacks = 0;
    [SerializeField] private float _startTimeBetweenAttacks = 0;
    [SerializeField] private float _attackMoveSpeed = 3f;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private int _meleeDamage = 15;
    [SerializeField] private Transform _attackPoint = null;
    [SerializeField] private GameObject _anchor = null;
    [SerializeField] private GameObject _daggerRig = null;
    [SerializeField] private float _rightFacing = -240f;
    [SerializeField] private float _leftFacing = -120f;
    private Animator _daggerAnimator;
    private bool _currentMoveStatus = false;

    //vfx
    [SerializeField]
    private GameObject _vfxAttack = null;

    //script reference
    private EnemyPatrol _ep;
    private EnemyHealth _eh;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;
        //_timeBetweenAttacks = _startTimeBetweenAttacks;
        _ep = GetComponent<EnemyPatrol>();
        _eh = GetComponent<EnemyHealth>();
        _daggerAnimator = GetComponentInChildren<Animator>();
    }

    //used if player is or not in range
    public void PlayerDetection()
    {
        if(!_eh._isDying)
        {
            if (_playerInSight == true)
            {
                AttackPlayer();
            }
            /*else
            {
                _ep.Patrol();
            }*/
            AnimationDirection();
        }
    }

    //gets into range if not in range
    private void AttackPlayer()
    {
        if (Vector2.Distance(transform.position, _player.position) <= _stoppingDistance)
        {
            WalkinganimationCheck(false);
            MeleeAttack();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, Time.deltaTime * _attackMoveSpeed);
            WalkinganimationCheck(true);
        }
    }

    //checks for the player
    private void MeleeAttack()
    {
        if(_timeBetweenAttacks <= 0)
        {
            Collider2D[] _hitPlayer = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);
            Vector3 _direction = _player.position - transform.position;
            float _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            _anchor.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
            foreach (Collider2D item in _hitPlayer)
            {
                if (item.tag == "Player")
                {
                    VFX();
                    item.GetComponent<PlayerHealth>().TakeDamage(_meleeDamage);
                    _daggerAnimator?.SetTrigger("Attack");
                    break;
                }
            }
            _timeBetweenAttacks = _startTimeBetweenAttacks;
        }
        else
        {
            _timeBetweenAttacks -= Time.deltaTime;
        }
    }

    //this is just to visualize the attack point
    private void OnDrawGizmosSelected()
    {
        if(_attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
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
            WalkinganimationCheck(false);
        }
    }


    //for walk animation
    private void WalkinganimationCheck(bool _input)
    {
        if(_currentMoveStatus != _input)
        {
            _daggerAnimator?.SetBool("IsWalking", _input);
            _currentMoveStatus = _input;
        }
    }

    //handles directions
    private void AnimationDirection()
    {
        if (_player?.position.x <= transform.position.x)
        {
            _daggerRig.transform.eulerAngles = new Vector3(0, _leftFacing, 0);
        }
        else
        {
            _daggerRig.transform.eulerAngles = new Vector3(0, _rightFacing, 0);
        }
    }

    private void VFX(){
        Instantiate(_vfxAttack, transform.position, transform.rotation);
    }
}
