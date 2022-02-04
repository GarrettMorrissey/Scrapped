using TMPro;
using UnityEngine;

public class SpawnMenu : MonoBehaviour
{
    private GameObject _playerVector = null;
    private Vector3 _spawnLocation;
    [SerializeField] private GameObject[] _spawnedObject = null;
    [SerializeField] private TextMeshProUGUI _currentItemText = null;
    [SerializeField] private TextMeshProUGUI _directionText = null;
    private bool _spawnDirection = false;
    private int _currentItem = 0;

    //spawns our desired object
    public void SpawnObject()
    {
        _playerVector = GameObject.FindGameObjectWithTag("Player");
        GetSpawnLocation();
        Instantiate(_spawnedObject[_currentItem], _spawnLocation, Quaternion.identity);        
    }

    //locates player then spawns
    private void GetSpawnLocation()
    {
        _spawnLocation = _playerVector.transform.position;
        if(_spawnDirection == true)
        {
            _spawnLocation.x += 5f;
        }
        else
        {
            _spawnLocation.x -= 5f;
        }
        _spawnLocation.y += 0.65f;
    }

    //cycle through items in list
    public void ChooseItemToSpawn()
    {
        _currentItem++;
        if(_currentItem >= _spawnedObject.Length)
        {
            _currentItem = 0;
        }
        _currentItemText.text = _currentItem.ToString();
    }

    //choose direction
    public void DirectionSwitch()
    {
        if(_spawnDirection == false)
        {
            _spawnDirection = true;
            _directionText.text = "Right";
        }
        else
        {
            _spawnDirection = false;
            _directionText.text = "Left";
        }
    }
}
