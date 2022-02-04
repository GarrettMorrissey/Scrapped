//-----------------------------------------------------------------------
// <copyright file="C:\Users\riley\Desktop\vfs\finaltermproject\5818_Scrapped\Assets\Scripts\Characters\Player\PlayerCharacter.cs" company="Amateur Hour">
//     Author: Riley Gauchier
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

public class PlayerCharacter : Character
{
    //script references
    private PlayerMovement _pm;
    private PlayerHealth _ph;
    private PlayerWeapon _pw;
    private PlayerPosition _pp;

    [HideInInspector] public int _pickupsCollected = 0;
    [HideInInspector] public int _trackPlayerHealth;
    [HideInInspector] public int _changeInPlayerHP = 0;
    [HideInInspector] public bool _damaged = false;
    [HideInInspector] public bool _healed = false;

    private void Awake()
    {
        _pm = GetComponent<PlayerMovement>();
        _ph = GetComponent<PlayerHealth>();
        _pw = GetComponentInChildren<PlayerWeapon>();
        _pp = GetComponent<PlayerPosition>();
        _trackPlayerHealth = _ph._currentHealth;
    }

    public override void CharacterMovement()
    {
        _pm.HandleMovement();
    }

    public override void CharacterAttack()
    {
        _pw.HandleShooting();
        //this is here to avaible to the update call in Character
        ReloadLevel();
    }

    public override void CharacterChangedHealth()
    {
        if(_damaged == true)
            PlayerDamaged(_changeInPlayerHP);
        else if (_healed == true)
            PlayerHealed(_changeInPlayerHP);
        else
            return;
    }

    private void PlayerDamaged(int _healthLoss)
    {
        _trackPlayerHealth = _ph.TakeDamage(_healthLoss);
        _damaged = false;
        _changeInPlayerHP = 0;
    }

    private void PlayerHealed(int _healthGain)
    {
        _trackPlayerHealth = _ph.RecoverHP(_changeInPlayerHP);
        _healed = false;
        _changeInPlayerHP = 0;
    }

    //in case we want to reset the scene
    private void ReloadLevel()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _pp.RespawnOnCheckPoint();
        }
    }
}
