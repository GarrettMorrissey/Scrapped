using UnityEngine;

public class JumpPlate : MonoBehaviour
{
    private EnemyHealth _eh;
    [SerializeField] private int _jumpDamage = 1;
    [SerializeField] private AK.Wwise.Event _dexterjumpoff = null;

    private void Awake()
    {
        _eh = GetComponentInParent<EnemyHealth>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            _eh.TakeDamage(_jumpDamage);
            AkSoundEngine.SetSwitch("Surfaces", "Enemy", gameObject);
            _dexterjumpoff.Post(gameObject);
        }
    }
}
