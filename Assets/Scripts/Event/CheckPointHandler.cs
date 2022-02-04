using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointHandler : MonoBehaviour
{
    private static CheckPointHandler _instance;
    private ShipStatus _ss;
    public Vector2 _lastCheckPoint;
    public int _grappleStatus;
    public int _bashStatus;
    private int _shipParts;
    [SerializeField] int _sceneToLoad = 5;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneloaded;
    }

    private void OnSceneloaded(Scene arg0, LoadSceneMode arg1)
    {
        LoadParts();
    }

    private void LoadParts()
    {
        _ss = GameObject.FindGameObjectWithTag("UICanvas")?.
        GetComponent<ShipStatus>();
        CheckShipParts();
    }

    public void ShipPartcollected()
    {
        _shipParts++;
        if (_shipParts >= 3)
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }

    private void CheckShipParts()
    {
        if (_shipParts >= 3)
        {
            _shipParts = 0;
            _grappleStatus = 0;
            _bashStatus = 0;
            _lastCheckPoint = new Vector2(0, 0);
        }
        else
        {
            CheckUICanvas(_shipParts);
        }
    }

    private void CheckUICanvas(int input)
    {
        if(input == 0)
        {
            return;
        }
        for (int i = 0; i < input; i++)
        {
            _ss.MakeIconActive(i);
        }
    }

    public int GetShipPartsNumber()
    {
        return _shipParts;
    }
}
