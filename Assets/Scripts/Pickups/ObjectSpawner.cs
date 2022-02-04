using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _pickupToSpawn = null;
    private bool _spawnTracker = false;
    [SerializeField] private float _spawnDelay = 6.0f;

    private void Awake()
    {
        StartItemSpawning();
    }

    //start or stop the coroutine
    private void StartItemSpawning()
    {
        if (_spawnTracker == false)
            StartCoroutine("SpawnObject");
        else
            StopCoroutine("SpawnObject");
    }

    //spawns our pickup
    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(_spawnDelay);
        Instantiate(_pickupToSpawn, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pickup"))
        {
            _spawnTracker = true;
            StopCoroutine("SpawnObject");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickup"))
        {
            _spawnTracker = false;
            StartCoroutine("SpawnObject");
        }
    }
}
