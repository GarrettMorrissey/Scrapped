using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointHandler _cph;
    
    [SerializeField] private GameObject _activationCircle = null;
    [SerializeField] private GameObject _activeLightsBeam = null;
    [SerializeField] private float _yOffset = 0.65f;
    [SerializeField] private AK.Wwise.Event _checkpointSound = null;

    private bool activated = false;

    void Start()
    {
        _cph = GameObject.FindGameObjectWithTag("CheckPointHandler").GetComponent<CheckPointHandler>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(activated) return;
        if(collision.tag == "Player")
        {
            _cph._lastCheckPoint = transform.position;
            _cph._lastCheckPoint.y += _yOffset;
          //VFX feedback
            ActivateCheckpointVFX();
            GetComponent<CheckPointLoopSound>()._control = true;
            _checkpointSound.Post(gameObject);
        }
    }

        //activates VFX lights
    public void ActivateCheckpointVFX()
    {
        //so VFX don't turn on every time players step on
        activated = true; 

        //inistial circle activation
        Instantiate(_activationCircle, transform.position + (transform.up * 0.75f), transform.rotation);
       
       //activates constant lights beaming
        _activeLightsBeam.SetActive(true);
    }
}
