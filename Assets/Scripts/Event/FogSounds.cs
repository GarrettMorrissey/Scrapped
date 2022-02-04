using UnityEngine;

public class FogSounds : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _fogOnEvent = null, _fogOffEvent = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _fogOnEvent.Post(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _fogOffEvent.Post(gameObject);
        }
    }
}
