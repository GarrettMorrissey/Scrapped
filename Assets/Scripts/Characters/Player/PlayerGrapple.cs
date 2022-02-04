using UnityEngine;

public class PlayerGrapple : MonoBehaviour
{
    [SerializeField] LayerMask _ropeLayerMask = default;
    [SerializeField] float _distance = 0;
    [SerializeField] float _ropeOffSet = 0.55f;
    [SerializeField] string _grappleStopSound = "Sfx_Grapple_Laser_Stop";
    [SerializeField] string _grapplePlaySound = "Sfx_Grapple_Laser_Play";
    private Vector3 _ropeTransform;
    private LineRenderer _lineRender;
    private DistanceJoint2D _rope;
    private Camera _mainCamera;
    private Vector2 _lookDirection;
    private Vector2 _movingAnchorOffset;
    private Transform _movingTransform;
    private Animator _animator;
    private bool _checker = true;
    public bool _grappleSwitch = false;
    private bool _moving = false;

    private MovingTerrain _movingTerrain = null;

    private void Awake()
    {
        _rope = GetComponent<DistanceJoint2D>();
        _lineRender = GetComponent<LineRenderer>();
        DestroyRope();
        _mainCamera = Camera.main;
        _animator = GetComponentInChildren<Animator>();
    }

    //used by player movement to see if grappled
    public bool CheckIsGrappling()
    {
        return (_rope.enabled == true && _lineRender.enabled == true);
    }

    //shoots a ray for the grapple
    private void HandleGrapple()
    {
        RopeOffSet();
        _lineRender.SetPosition(0, _ropeTransform);

        _lookDirection = _mainCamera.ScreenToWorldPoint(Input.mousePosition) - _ropeTransform;
        Debug.DrawLine(transform.position, _lookDirection);

        if (Input.GetMouseButtonDown(1) && _checker == true)
        {
            RaycastHit2D _hit = Physics2D.Raycast(_ropeTransform, _lookDirection, _distance, _ropeLayerMask);

            if (_hit.collider != null)
            {
                _checker = false;
                SetRope(_hit);
                _animator?.SetTrigger("Grapple");
                AkSoundEngine.PostEvent(_grapplePlaySound, gameObject);
            }
        }
        else if (Input.GetMouseButtonDown(1) && _checker == false)
        {
            _checker = true;
            DestroyRope();
            _animator?.SetTrigger("GrappleStop");
            AkSoundEngine.PostEvent(_grappleStopSound, gameObject);
        }

        AnchorUpdate();
    }

    //this offsets the rope so its not in the players feet
    private void RopeOffSet()
    {
        _ropeTransform = transform.position;
        _ropeTransform.y += _ropeOffSet;
    }

    //makes the rope
    void SetRope(RaycastHit2D hit)
    {
        _rope.enabled = true;
        _rope.connectedAnchor = hit.point;

        _lineRender.enabled = true;
        _lineRender.SetPosition(1, hit.point);
        _moving = CheckIfMoving(hit);
    }

    //removes the rope
    void DestroyRope()
    {
        _rope.enabled = false;
        _lineRender.enabled = false;
    }

    //if player does have the bash upgrade it allows the player to bash
    public void CheckIfGrappleUpgraded()
    {
        if (_grappleSwitch == true)
            HandleGrapple();
        else
            return;
    }

    //if the platfomr has the moving script
    private bool CheckIfMoving(RaycastHit2D _raycastHit2D)
    {
        _movingTerrain = _raycastHit2D.collider.GetComponent<MovingTerrain>();
        if(_movingTerrain != null)
        {
            _movingTransform = _raycastHit2D.collider.transform;
            _movingAnchorOffset = _raycastHit2D.point - (Vector2)_movingTransform.position;
            return true;
        }
        else
        {
            return false;
        }
    }

    //updates the anchor point for grapple
    private void AnchorUpdate()
    {
        if (_moving)
        {
            Vector2 _temp = (Vector2)_movingTransform.position + _movingAnchorOffset;
            _lineRender.SetPosition(1, _temp);
            _rope.connectedAnchor = _temp;
        }
    }
}
