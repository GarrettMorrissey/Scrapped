using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField] private GameObject _dust = null;

    public void DustCloud()
    {
        Instantiate(_dust, transform.position, Quaternion.identity);
    }
}
