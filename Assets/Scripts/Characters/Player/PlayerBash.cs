//-----------------------------------------------------------------------
// <copyright file="C:\Users\riley\Desktop\vfs\finaltermproject\5818_Scrapped\Assets\Scripts\Characters\Player\PlayerBash.cs" company="Amateur Hour">
//     Author: Riley Gauchier
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

public class PlayerBash : MonoBehaviour
{
    //for trigger
    [SerializeField] private GameObject _bashZone = null;
    public float _timeBetweenBash = 1f;
    private bool _bashOn = false;
    public bool _bashSwitch = false;

    //for movement
    public float _bashSpeedMultipler = 1f;
    [SerializeField] private float _bashSpeed = 0;
    [SerializeField] private float _startBashTime = 0;
    private int _bashDirection;
    private Rigidbody2D _rb2d;
    [SerializeField] private GameObject _bashAim = null;

    //animator reference
    private Animator _animator;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    //starts our bash
    private void StartBash()
    {
        if (_bashOn == false)
        {
            if(Input.GetKeyDown(KeyCode.LeftControl) || 
                Input.GetKeyDown(KeyCode.LeftCommand) ||
                Input.GetKeyDown(KeyCode.LeftShift))
            {
                BashMove();
            }
        }
    }

    //if player does have the bash upgrade it allows the player to bash
    public void CheckIfBashUpgraded()
    {
        if (_bashSwitch == true)
            StartBash();
        else
            return;
    }

    //moves player right or left quickly
    //known issue causes the player to not move from current location sometimes but still actives
    private void BashMove()
    {
        if (MouseCheck())
        {
            _bashDirection = 1;
        }
        else
        {
            _bashDirection = 2;
        }
        _animator?.SetTrigger("Bash");
        if (_bashDirection == 1)
            _rb2d.velocity = Vector2.left * _bashSpeed * _bashSpeedMultipler;
        else if (_bashDirection == 2)
            _rb2d.velocity = Vector2.right * _bashSpeed * _bashSpeedMultipler;
        _bashOn = true;
        _bashZone.SetActive(true);
        Invoke("BashZoneReset", _startBashTime);
    }

    //turns off bashzone
    private void BashZoneReset()
    {
        _bashZone.SetActive(false);
        Invoke("ResetBash", _timeBetweenBash);
    }

    private void ResetBash()
    {
        _bashOn = false;
    }

    //comepares location to that of the sight, controlled by mouse
    private bool MouseCheck()
    {
        if (_bashAim.transform.position.x < transform.position.x)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
