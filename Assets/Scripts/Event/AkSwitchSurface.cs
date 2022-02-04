using UnityEngine;

public class AkSwitchSurface : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Switch _groundSwitch = null;
    //[SerializeField] private string _validTag = "Player";
    [SerializeField] private GameObject _validObject = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == _validObject)
        {
            _groundSwitch.SetValue(collision.gameObject);
        }
    }
}
