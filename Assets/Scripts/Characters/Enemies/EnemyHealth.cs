//-----------------------------------------------------------------------
// <copyright file="C:\Users\riley\Desktop\vfs\finaltermproject\5818_Scrapped\Assets\Scripts\Characters\Enemies\EnemyHealth.cs" company="Amateur Hour">
//     Author: Riley Gauchier
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int _enemyHealth;
    [SerializeField] private int _lootDecison = 2;
    [SerializeField] private GameObject[] _loot = null;
    [SerializeField] private GameObject _lootSpawn = null;
    private int _lootSelection;
    [SerializeField] private int _type = 0;
    [HideInInspector] public bool _isDying = false;
    private Animator _animator;
    private BoxCollider2D _bc2d;
    [SerializeField] private BoxCollider2D _cbc2d = null;
    private Rigidbody2D _rb2d;
    [SerializeField] float _corpseTime = 2f;

    //VFX
    [SerializeField]
    private GameObject _vfxEnemyDeath = null;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _bc2d = GetComponent<BoxCollider2D>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    //checks if enemy is alive
    public void TakeDamage(int _damage)
    {
        _enemyHealth -= _damage;
        if (_enemyHealth <= 0 && !_isDying)
        {
            EnemyDie();
        }
        if (_damage != 0 && !_isDying)
        {
            DamageType();
        }
    }

    private void EnemyDie()
    {
        VFXDeath();
        ChooseLoot();
        _isDying = true;
        DeathType();
    }

    //this determines if loot is dropped, and which item is to be dropped
    private void ChooseLoot()
    {
        if (_loot.Length != 0)
        {
            int _lootChance = Random.Range(0, _lootDecison);
            if(_lootChance == 0)
            {
                _lootSelection = Random.Range(0, _loot.Length);
                Instantiate(_loot[_lootSelection], _lootSpawn.transform.position, Quaternion.identity);
            }
        }
    }

    private void DamageType()
    {
        switch(_type)
        {
            case 0:
                _animator?.SetTrigger("BomberDamaged");
                break;
            case 1:
                _animator?.SetTrigger("DaggerDamaged");
                break;
            case 2:
                _animator?.SetTrigger("BossDamaged");
                break;
            default:
                break;
        }
    }

    private void DeathType()
    {
        switch (_type)
        {
            case 0:
                TurnOffColliders();
                _animator?.SetTrigger("BomberDying");
                float bomberclipLength = _animator.GetCurrentAnimatorStateInfo(0).length + _corpseTime;
                Destroy(gameObject, bomberclipLength);
                break;
            case 1:
                TurnOffColliders();
                _animator?.SetTrigger("DaggerDying");
                float daggerclipLength = _animator.GetCurrentAnimatorStateInfo(0).length + _corpseTime;
                Destroy(gameObject, daggerclipLength);
                break;
            case 2:
                TurnOffColliders();
                _animator?.SetTrigger("BossDying");
                float bossclipLength = _animator.GetCurrentAnimatorStateInfo(0).length;
                Destroy(gameObject, bossclipLength);
                break;
        }
    }

    private void TurnOffColliders()
    {
        _bc2d.enabled = false;
        _cbc2d.enabled = false;
        _rb2d.gravityScale = 0;
    }

    private void VFXDeath(){
        Instantiate(_vfxEnemyDeath, transform.position, Quaternion.identity);
    }
}
