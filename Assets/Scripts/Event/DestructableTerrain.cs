using UnityEngine;

public class DestructableTerrain : MonoBehaviour
{
    private BoxCollider2D _doorCollider;
    [SerializeField]
    private GameObject _doorRender = null;

    [Header("Door Animation")]
    [SerializeField]
    private GameObject _doorAnimation = null;
    [SerializeField]
    private GameObject _vfx = null;


    private void Awake()
    {
        _doorCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BashZone"))
        {
            _doorCollider.enabled = false;
            _doorRender.SetActive(false);
            //Animation
            Instantiate(_doorAnimation, transform.position, transform.rotation);
            Instantiate(_vfx, transform.position, transform.rotation);
        }
    }
}
