using UnityEngine;

public class GrappleUpgradePickup : BasePickup
{
    private PlayerGrapple _pg;
    private UpgradeStatus _us;
    public AK.Wwise.Switch _grappleSwitch;
    private bool _triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _pg = collision.GetComponent<PlayerGrapple>();
            if (_pg._grappleSwitch == false)
            {
                if (_triggered == false)
                {
                    _triggered = true;
                    HandlePSM(collision);
                    _us = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UpgradeStatus>();
                    _us.IconSwitch(2);
                    _grappleSwitch.SetValue(gameObject);
                    Destroy(gameObject);
                }
            }
        }
    }
}
