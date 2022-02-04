using UnityEngine;

public class ShipPartSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _shipPart = null;
    [SerializeField] private int _partIndex = 0;
    private int _savedParts;

    // Start is called before the first frame update
    void Start()
    {
        _savedParts = GameObject.FindGameObjectWithTag("CheckPointHandler").
                GetComponent<CheckPointHandler>().
                GetShipPartsNumber();
        if(0 >= _partIndex - _savedParts)
        {
            return;
        }
        Instantiate(_shipPart, transform.position, Quaternion.identity);
    }

    
}
