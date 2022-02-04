using UnityEngine;

public class BashUpgradePickup : BasePickup
{
    private PlayerBash _pb;
    private UpgradeStatus _us;
    public AK.Wwise.Switch _bashSwitch;
    private bool _triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _pb = collision.GetComponent<PlayerBash>();
            if (_pb._bashSwitch == false)
            {
                if(_triggered == false)
                {
                    _triggered = true;
                    HandlePSM(collision);
                    _us = GameObject.FindGameObjectWithTag("UICanvas")?.GetComponent<UpgradeStatus>();
                    _us.IconSwitch(3);
                    _bashSwitch.SetValue(gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
