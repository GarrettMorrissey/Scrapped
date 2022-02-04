using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _bulletLifeTime = 3f;
    [SerializeField] private float _speed = 20f;

    private void Awake()
    {
        //if no collisions in liftime destroy self
        Destroy(gameObject, _bulletLifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            PlayerHealth _ph = collider.GetComponent<PlayerHealth>();
            _ph.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else if (collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
