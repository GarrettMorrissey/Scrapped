using UnityEngine;
using System.Collections;

public class BossHealthTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _bossHPBar = null;
    private MainCameraMovement _mcm;
    [SerializeField] private float _fovIncrease = 10f;
    private float _startFov;
    private bool _triggered = false;

    private void Awake()
    {
        _mcm = Camera.main.GetComponent<MainCameraMovement>();
        _startFov = _mcm._fovVariable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && _triggered == false)
        {
            _triggered = true;
            _bossHPBar.SetActive(true);
            StartCoroutine("ZoomOut");
        }
    }

    IEnumerator ZoomOut()
    {
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime / 2;
            _mcm._fovVariable = Mathf.Lerp(_startFov, _startFov + _fovIncrease, t);
            yield return null;
        }
    }
}
