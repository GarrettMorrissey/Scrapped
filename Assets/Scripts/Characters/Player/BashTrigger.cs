using UnityEngine;

public class BashTrigger : MonoBehaviour
{
    [SerializeField] private int _damage = 0;
    [SerializeField] private AK.Wwise.Event _bashHitSound = null, _wallBreak = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            EnemyCharacter _ec = collision.collider.GetComponent<EnemyCharacter>();
            _ec._enemyLostHealth = _damage;
        }
        if(collision.collider.tag == "Enemy" || collision.collider.tag == "Ground")
        {
            _bashHitSound.Post(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Break"))
        {
            _wallBreak.Post(gameObject);
        }
    }
}
