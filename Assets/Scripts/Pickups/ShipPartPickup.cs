using UnityEngine;

public class ShipPartPickup : BasePickup
{
    [SerializeField] private int _shipHUDIconIndex = 0;
    private ShipStatus _ss;
    private CheckPointHandler _cph;
    private bool _triggered = false;
    public AK.Wwise.Switch _shipPartSwitch;

    private void Awake()
    {
        _ss = GameObject.FindGameObjectWithTag("UICanvas").
                GetComponent<ShipStatus>();
        _cph = GameObject.FindGameObjectWithTag("CheckPointHandler").
                GetComponent<CheckPointHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (_triggered == false)
            {
                _triggered = true;
                HandlePSM(collision);
                _ss.MakeIconActive(_shipHUDIconIndex);
                _cph.ShipPartcollected();
                _shipPartSwitch.SetValue(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
