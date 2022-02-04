using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 0;
    [SerializeField] private int _damage = 0;
    [SerializeField] private float _bulletLifeTime = 0;
    [SerializeField] private GameObject _vfx = null;
    private Rigidbody2D _rb2d;
    public int _damageMultiplier;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.AddForce(transform.right * _speed, ForceMode2D.Impulse);
        //if no collisions in liftime destroy self
        Destroy(gameObject, _bulletLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HitVFX();
        if (collision.collider.tag == "Enemy")
        {
            EnemyCharacter _ec = collision.collider.GetComponent<EnemyCharacter>();
            if(_ec != null)
            {
                _ec._enemyLostHealth = _damage * _damageMultiplier;
            }
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "JumpPlate")
        {
            EnemyCharacter _ec = collision.collider.GetComponentInParent<EnemyCharacter>();
            if (_ec != null)
            {
                _ec._enemyLostHealth = _damage * _damageMultiplier;
            }
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "Ground" || collision.collider.tag == "Break")
        {
            Destroy(gameObject);
        }
        else if (collision.collider.tag == "EnemyBullets")
        {
            EnemyBomb _eb = collision.gameObject.GetComponent<EnemyBomb>();
            if(_eb != null)
            {
                _eb.Explode();
            }
            Destroy(gameObject);
        }
    }

    public void HitVFX(){
        Instantiate(_vfx, transform.position, transform.rotation);
    }
}
