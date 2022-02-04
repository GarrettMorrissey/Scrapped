using UnityEngine;

public class EnvironmentalStates : MonoBehaviour
{
    [SerializeField] AK.Wwise.Event _thisEnvironment = null;
    private bool _playerIsIn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && _playerIsIn == false)
        {
            _playerIsIn = true;
            _thisEnvironment.Post(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && _playerIsIn == true)
        {
            _playerIsIn = false;
        }
    }
}
