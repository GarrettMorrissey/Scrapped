using UnityEngine;

public class ToxicSounds : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _toxicEnterEvent = null, _toxicExitEvent = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _toxicEnterEvent.Post(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _toxicExitEvent.Post(gameObject);
        }
    }
}
