using UnityEngine;

public class DoubleJumpUpgradePickup : BasePickup
{
    private PlayerMovement _pm;
    private UpgradeStatus _us;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _pm = collision.GetComponent<PlayerMovement>();
            if (_pm._jumpSwitch == false)
            {
                HandlePSM(collision);
                _us = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UpgradeStatus>();
                _us.IconSwitch(1);
                Destroy(gameObject);
            }
        }
    }
}
