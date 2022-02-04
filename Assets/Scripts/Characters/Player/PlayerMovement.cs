//-----------------------------------------------------------------------
// <copyright file="C:\Users\riley\Desktop\vfs\finaltermproject\5818_Scrapped\Assets\Scripts\Characters\Player\PlayerMovement.cs" company="Amateur Hour">
//     Author: Riley Gauchier
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //main movement variables
    public float _statsMenuMultipler = 1f;
    [SerializeField] private float _playerMoveSpeed = 0;
    [SerializeField] private float _acceleration = 5f;
    [SerializeField] private Rigidbody2D _rb = null;
    private float _horizontal;
    private bool _isMoving;

    //jump variables
    private bool _isGrounded;
    [SerializeField] private float _jumpForce = 0;
    public float _extraHeight = 1f;
    [SerializeField] private int _jumpLimit = 0;
    [SerializeField] private float _airControl = 0.25f;
    [SerializeField] private float _normalJump = 1f;
    [SerializeField] private float _enemyJump = 0.75f;
    private int _holdjumpInput;

    //switch controls for upgrades
    public bool _jumpSwitch = false;

    //our camera
    private Camera _mainCamera;

    //for grappling
    private bool _isGrappled;
    private Vector3 _grappleVector;
    private float _grappleHorizontal;
    private float _grappleVertical;
    private bool _whooshPlaying = false;

    //access other scripts
    private PlayerGrapple _pg;
    private PlayerBash _pb;
    private PlayerGroundTrigger _pgt;
    private PlayerPosition _pp;
    private PlayerSounds _ps;

    //animator reference
    private Animator _animator;
    private bool _isWalking = false;
    [SerializeField] private GameObject _playerRig = null;
    [SerializeField] private float _rightFacing = 120f;
    [SerializeField] private float _leftFacing = 240f;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _pb = GetComponent<PlayerBash>();
        _pg = GetComponent<PlayerGrapple>();
        _pgt = GetComponentInChildren<PlayerGroundTrigger>();
        _pp = GetComponent<PlayerPosition>();
        _ps = GetComponentInChildren<PlayerSounds>();
        _holdjumpInput = _jumpLimit;
        _animator = GetComponentInChildren<Animator>();
    }

    //to reset jumps when player lands
    private void FixedUpdate()
    {
        CheckForGround();
    }

    //the called function of this script, holds the calls to other functions in this script
    public void HandleMovement()
    {
        ResetPostion();
        SingleJump();
        MovementCheck();
        WalkinganimationCheck();
    }

    //for ground movement
    private void SimpleMove()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _isMoving = Mathf.Abs(_horizontal) > 0.05f;
        
        Vector2 targetVelocity = new Vector3(_horizontal * _playerMoveSpeed * _statsMenuMultipler, _rb.velocity.y, 0);
        Vector2 currentVelocity = _rb.velocity;
        float control = _isGrounded ? 1f : _airControl * Mathf.Abs(_horizontal);
        if (currentVelocity.magnitude > _playerMoveSpeed)
        {
            control = 1f;
        }
        Vector2 lerpedVelocity = Vector2.Lerp(currentVelocity, targetVelocity, Time.deltaTime * _acceleration * control);
        _rb.velocity = lerpedVelocity;

        AnimationDirection();
    }

    private void AnimationDirection()
    {
        if (_isMoving)
        {
            if (Mathf.Sign(_horizontal) < 0)
            {
                _playerRig.transform.eulerAngles = new Vector3(0, _leftFacing, 0);
                _playerRig.transform.localScale = new Vector3(-2, 2, 2);
            }
            else
            {
                _playerRig.transform.eulerAngles = new Vector3(0, _rightFacing, 0);
                _playerRig.transform.localScale = new Vector3(2, 2, 2);
            }
        }
    }

    //controls when player can jump once
    private void SingleJump()
    {
        if (_isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                JumpTriggered(_normalJump);
            }
        }
    }

    private void JumpTriggered(float _type)
    {
        _rb.velocity = Vector3.up * _jumpForce * _extraHeight * _type;
        _animator?.SetTrigger("Jump");
    }

    //checks if player in on the ground
    private void CheckForGround()
    {
        _isGrounded = _pgt.ReturnJumpBool();
        _animator?.SetBool("IsGrounded", _isGrounded);
    }

    //handles movement when grappled
    private void GrappleMove()
    {
        _grappleHorizontal = Input.GetAxis("Horizontal");
        _grappleVertical = Input.GetAxis("Vertical");

        _grappleVector = new Vector3(_grappleHorizontal, _grappleVertical, 0);
        _grappleVector = _grappleVector.normalized * (_playerMoveSpeed * _statsMenuMultipler * Time.deltaTime);
        GrappleWhoosh(_grappleVector);
        transform.position += _grappleVector;
    }

    private void GrappleWhoosh(Vector3 _grappleVector)
    {
        if(_grappleVector.x != 0 || _grappleVector.y != 0)
        {
            if(_whooshPlaying == false)
            {
                _ps.GrappleWhooshPlay();
                _whooshPlaying = true;
            }
        }
        else if (_grappleVector.x == 0 && _grappleVector.y == 0)
        {
            _whooshPlaying = false;
        }
    }

    //called if player falls off stage
    private void ResetPostion()
    {
        if (transform.position.y < -10)
        {
            _pp.RespawnOnCheckPoint();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    //Checks for which kind of movement the player is doing
    private void MovementCheck()
    {
        _isGrappled = _pg.CheckIsGrappling();
        _pg.CheckIfGrappleUpgraded();
        if (_isGrappled == true)
        {
            GrappleMove();
        }
        else
        {
            SimpleMove();
            _pb.CheckIfBashUpgraded();
        }
    }

    //for walk animation
    private void WalkinganimationCheck()
    {
        _isWalking = _horizontal != 0;
        _animator?.SetFloat("_speed", Mathf.Abs(_horizontal));
    }

    //sets bools in animator to true
    private void JumpAnimationBoolTrue(string _boolValue)
    {
        _animator?.SetBool(_boolValue, true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "JumpPlate")
        {
            JumpTriggered(_enemyJump);
        }
    }
}
