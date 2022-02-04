using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picked_pickup : MonoBehaviour
{
    [SerializeField]
    private GameObject _pickupVFX = null;

    [SerializeField]
    private float _timer = 4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            PlayPickup();
        }
    }

    private void PlayPickup(){
        GameObject pickup = Instantiate(_pickupVFX, transform.position,  Quaternion.identity);
        Destroy(pickup, _timer);
    }
}
