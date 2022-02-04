using UnityEngine;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour
{
    private int _bossStage = 0;
    [SerializeField] private int _stage2HPAmount = 30;
    [SerializeField] private int _stage3HPAmount = 15;

    [SerializeField] private Image _healthBar = null;
    private float _healthTracker;
    private float _StartingHealth;

    [SerializeField] AK.Wwise.RTPC _hoverVelocity = null;
    [SerializeField] AK.Wwise.Event _hoverSoundPlay = null, _hoverSoundStop = null;

    //script references
    private BossHandler _bh;
    private BossAttack _ba;
    private EnemyHealth _eh;

    private void Awake()
    {
        _bh = GetComponent<BossHandler>();
        _ba = GetComponent<BossAttack>();
        _eh = GetComponent<EnemyHealth>();
        _healthTracker = _eh._enemyHealth;
        _StartingHealth = _eh._enemyHealth;
    }

    private void Start()
    {
        _hoverSoundPlay.Post(gameObject);
    }

    private void OnDestroy()
    {
        _hoverSoundStop.Post(gameObject);
    }

    public void BossStageSelection()
    {
        HealthMonitor();
        CheckHP();
        _bh.StageHandler(_bossStage);
        _ba.PlayerDetection();
        _hoverVelocity.SetValue(gameObject, _bh._speed);
    }

    private void HealthMonitor()
    {
        if(_eh._enemyHealth > _stage2HPAmount)
        {
            _bossStage = 0;
        }
        else if(_eh._enemyHealth <= _stage2HPAmount && _eh._enemyHealth > _stage3HPAmount)
        {
            _bossStage = 1;
        }
        else if(_eh._enemyHealth <= _stage3HPAmount)
        {
            _bossStage = 2;
        }
    }

    private void CheckHP()
    {
        _healthTracker = _eh._enemyHealth;
        _healthBar.fillAmount = _healthTracker / _StartingHealth;
    }
}
