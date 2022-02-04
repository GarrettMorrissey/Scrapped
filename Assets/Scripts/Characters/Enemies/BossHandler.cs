using System.Collections;
using UnityEngine;

public class BossHandler : MonoBehaviour
{
    //movement variables
    public float _speed { get; private set; } = 1f;
    [SerializeField] private float _speedIncreaseValue = 1f;
    [SerializeField] private float _maxRangeFloat = 3, _minRangeFloat = 3;
    [SerializeField] private float _teleportCallDelay = 0.5f, _flyTimeLimit = 10f;
    private bool _canTeleport = false;
    private bool _spawnersOn = false;
    private Animator _bossAnimator;

    //spawners
    [SerializeField] private GameObject[] _spawners = null;

    //script references
    private BossFlyPattern _bfp;
    private BossTeleport _bt;
    private BossAttack _ba;

    private void Awake()
    {
        _bfp = GetComponent<BossFlyPattern>();
        _bt = GetComponent<BossTeleport>();
        _bossAnimator = GetComponentInChildren<Animator>();
        ResetFlyingTransforms();
    }

    //will be called by EnemyBoss to determine what movements the boss will do
    public void StageHandler(int _bossStage)
    {
        if(_bossStage == 0)
        {
            _bfp.FlyPattern(true);
        }
        else if(_bossStage == 1)
        {
            CanTeleport();
        }
        else
        {
            SpawnersSwitch(_spawnersOn);
        }
    }

    //so we can turn on/off flying
    private void FlyingSwitch(bool _input)
    {
        _bfp.FlyPattern(_input);
    }

    //to make calling flyingtransforms easy
    private void ResetFlyingTransforms()
    {
        _bfp.SetValues(_speed, _maxRangeFloat, _minRangeFloat);
        _bfp.NewTransforms();
    }

    private void SetSpeed()
    {
        _speed += _speedIncreaseValue;
    }

    IEnumerator UseTeleport()
    {
        _bfp.DirectionRoutineSwitch(false);
        RoutineHandler(false, "FlyTime");
        FlyingSwitch(false);
        _bossAnimator?.SetTrigger("BossTeleport");
        _bt.CallTeleport();
        yield return new WaitForSeconds(_teleportCallDelay);
        ResetFlyingTransforms();
        FlyingSwitch(true);
        _bfp.DirectionRoutineSwitch(true);
        RoutineHandler(true, "FlyTime");
    }

    IEnumerator FlyTime()
    {
        RoutineHandler(false, "UseTeleport");
        yield return new WaitForSeconds(_flyTimeLimit);
        RoutineHandler(true, "UseTeleport");
    }

    private void RoutineHandler(bool _control, string _routine)
    {
        if(_control)
        {
            StartCoroutine(_routine);
        }
        else
        {
            StopCoroutine(_routine);
        }
    }

    //turns on spawners
    private void SpawnersSwitch(bool _status)
    {
        if(_status == false)
        {
            foreach (GameObject item in _spawners)
            {
                item.SetActive(true);
            }
            _spawnersOn = true;
            SetSpeed();
        }
    }

    //this is so I don't call the routines multiple times
    private void CanTeleport()
    {
        if(_canTeleport == false)
        {
            RoutineHandler(true, "FlyTime");
            _canTeleport = true;
            SetSpeed();
        }
    }
}
