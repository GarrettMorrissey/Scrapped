using UnityEngine;

public class HealthPickup : BasePickup
{
    private PlayerHealth _ph = null;
    [SerializeField] int _healAmount = 5;

    [Header("VFX")]
    [SerializeField]
    private GameObject _vfxHealth = null;
    [SerializeField]
    private GameObject _vfxNonHealth = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _ph = collision.GetComponent<PlayerHealth>();
            CheckHealth(collision);
        }
    }

    private void HealPlayer()
    {
        HealthVFX();
        _ph.RecoverHP(_healAmount);
        Destroy(gameObject);
    }

    private void CheckHealth(Collider2D collision)
    {
        if (_ph._currentHealth >= _ph._ratioControl)
        {
            NonHealthVFX();
            Destroy(gameObject);
        }
        else
        {
            HandlePSM(collision);
            HealPlayer();
        }
    }

    public void HealthVFX()
    {
        Instantiate(_vfxHealth, transform.position, transform.rotation);
    }
    public void NonHealthVFX()
    {
        Instantiate(_vfxNonHealth, transform.position, transform.rotation);
    }
}
