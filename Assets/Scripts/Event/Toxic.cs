using UnityEngine;

public class Toxic : MonoBehaviour
{
    private float _timeBetweenDamage;
    [SerializeField] private float _startTime = 1f;
    [SerializeField] private int _damage = 15;
    [SerializeField] private int _enemyDamage = 1;

    private void Start()
    {
        _timeBetweenDamage = _startTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DamageOverTime(collision);
    }

    private void DamageOverTime(Collider2D collision)
    {
        if(_timeBetweenDamage <= 0 && collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(_damage);
            _timeBetweenDamage = _startTime;
        }
        else if(_timeBetweenDamage <= 0 && collision.CompareTag("JumpPlate"))
        {
            collision.GetComponentInParent<EnemyHealth>().TakeDamage(_enemyDamage);
            _timeBetweenDamage = _startTime;
        }
        else
        {
            _timeBetweenDamage -= Time.deltaTime;
        }
    }
}
