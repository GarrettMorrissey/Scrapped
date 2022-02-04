//-----------------------------------------------------------------------
// <copyright file="C:\Users\riley\Desktop\vfs\finaltermproject\5818_Scrapped\Assets\Scripts\Event\EnemySpawner.cs" company="Amateur Hour">
//     Author: Riley Gauchier
//     Copyright (c) All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToSpawn = null;
    [SerializeField] private GameObject _portalObject = null;
    private GameObject _currentSpawn;
    [SerializeField] private float _delayInSpawning = 6;
    [SerializeField] private float _portalTime = 1f;
    private bool _isSpawning = false;
    //private bool _spawnClear = true;
    [SerializeField] private AK.Wwise.Event _portalSound = null;
    //[SerializeField] private bool _isPatroling = false;

    private EnemyPatrol _ep;

    private void Update()
    {
        SpawnEnemy();
    }

    //spawns our enemy
    private void SpawnEnemy()
    {
        if(_currentSpawn == null && !_isSpawning)
        {
            StartCoroutine("EnemyRespawner");
        }
    }

    //this is to make sure the spawner only spawns after a delay and not constantly
    IEnumerator EnemyRespawner()
    {
        _isSpawning = true;
        yield return new WaitForSeconds(_delayInSpawning);
        _portalSound.Post(gameObject);
        _currentSpawn = Instantiate(_enemyToSpawn, transform.position, Quaternion.identity);
        _portalObject?.SetActive(true);
        _isSpawning = false;
        /*if(_isPatroling)
        {
            _ep = _currentSpawn.GetComponent<EnemyPatrol>();
            _ep._spawnedWillPatrol = true;
            _ep._spawnedLocation = transform.position;
        }*/
        Invoke("TurnOffPortal", _portalTime);
    }

    private void TurnOffPortal()
    {
        _portalObject?.SetActive(false);
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "JumpPlate")
        {
            _spawnClear = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "JumpPlate")
        {
            _spawnClear = true;
        }
    }*/
}
