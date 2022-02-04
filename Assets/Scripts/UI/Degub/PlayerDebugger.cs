using UnityEngine;

public class PlayerDebugger : MonoBehaviour
{
    private PlayerHealth _ph;
    private UpgradeStatus _us;

    private void Start()
    {
        _ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _us = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UpgradeStatus>();
    }

    public void HealthButton()
    {
        if(_ph._currentHealth < _ph._ratioControl)
        {
            _ph.RecoverHP(25);
        }
    }

    public void GodModeButton()
    {
        if (_ph._damageSwitch == true)
        {
            _ph._damageSwitch = false;
        }
        else
        {
            _ph._damageSwitch = true;
        }
    }

    public void DamageButton()
    {
        if(_ph._currentHealth > 0)
        {
            _ph.TakeDamage(25);
        }
    }

    public void GrappleButton()
    {
        _us.IconSwitch(2);
    }

    public void BashButton()
    {
        _us.IconSwitch(3);
    }
}
