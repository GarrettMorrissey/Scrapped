using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect = null;
    [SerializeField] private float _delay = 3f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Explode), _delay);
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
    }

    //explodes the bomb
    public void Explode()
    {
        Instantiate(_explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerHealth _ph = collider.GetComponent<PlayerHealth>();
            _ph.TakeDamage(_damage);
            Explode();
        }
    }



}
