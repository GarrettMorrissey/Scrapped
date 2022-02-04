using UnityEngine;

public class ShipStatus : MonoBehaviour
{
    [SerializeField] GameObject[] _icons = null;

    public void MakeIconActive(int _index)
    {
        if(_icons[_index].activeInHierarchy == false)
        {
            _icons[_index].SetActive(true);
        }
    }
}
