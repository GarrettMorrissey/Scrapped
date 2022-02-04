using UnityEngine;

public class Eyes : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth = null;

    [Header("eyes")]
    [SerializeField] private GameObject _opened = null;
    [SerializeField] private GameObject _mid = null;
    [SerializeField] private GameObject _closed = null;

    private void Start()
    {
        _opened.SetActive(true);
    }

    private void Update()
    {
        CloseAll();
        if(_playerHealth._currentHealth <= 25)
        {
            _closed.SetActive(true);
        }
        else if(_playerHealth._currentHealth <= 40)
        {
            _mid.SetActive(true);
        }
        else
        {
            _opened.SetActive(true);
        }
    }

    private void CloseAll()
    {
        _opened.SetActive(false);
        _mid.SetActive(false);
        _closed.SetActive(false);
    }
}
