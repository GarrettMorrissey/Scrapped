using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPosition : MonoBehaviour
{
    private CheckPointHandler _cph;
    [SerializeField] GameObject[] _listOfCheckPoints = null;
    private int _listIndex = 0;
    [SerializeField] private float _invokeDelay = 0.8f;
    [SerializeField] private float _offsetTeleport = 0.65f;

    private void Start()
    {
        _cph = GameObject.FindGameObjectWithTag("CheckPointHandler").GetComponent<CheckPointHandler>();
        transform.position = _cph._lastCheckPoint;
    }

    public void RespawnOnCheckPoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //lets player teleport to next checkpoint in list
    void Teleport()
    {
        if(_listIndex == _listOfCheckPoints.Length)
        {
            _listIndex = 0;
        }
        transform.position = TeleportOffset(_listOfCheckPoints[_listIndex].transform.position);
        _listIndex++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Teleport();
        }
    }

    public void CallReload()
    {
        Invoke("RespawnOnCheckPoint", _invokeDelay);
    }

    private Vector3 TeleportOffset(Vector3 _location)
    {
        return new Vector3(_location.x, _location.y + _offsetTeleport, _location.z);
    }
}
