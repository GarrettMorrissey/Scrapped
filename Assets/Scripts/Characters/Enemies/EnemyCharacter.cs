using UnityEngine;

public class EnemyCharacter : Character
{
    //script references

    private EnemyHealth _eh;
    private EnemyPatrol _ep;
    private EnemyRangedAttack _era;
    private EnemyMeleeAttack _ema;
    private EnemyBoss _eb;
    private EnemyType _et;
    public int _holdType = 0;

    [HideInInspector]  public int _enemyLostHealth = 0;

    private void Awake()
    {
        _eh = GetComponent<EnemyHealth>();
        _et = GetComponent<EnemyType>();
        GetEnemyType();
    }

    private void OnBecameVisible()
    {
        ++MusicIntensity._enemiesOnScreen;
    }

    private void OnBecameInvisible()
    {
        --MusicIntensity._enemiesOnScreen;
    }

    public override void CharacterAttack()
    {
        if (_holdType == 0)
        {
            _era.PlayerDetection();
        }
        else if(_holdType == 1)
        {
            _ema.PlayerDetection();
        }
        else if(_holdType == 2)
        {
            _eb.BossStageSelection();
        }
    }

    public override void CharacterChangedHealth()
    {
        _eh.TakeDamage(_enemyLostHealth);
        _enemyLostHealth = 0;
    }

    //get reference to enemy type
    private void GetEnemyType()
    {
        _holdType = _et.WhichTypeOfEnemy();
        TypeSwitch();
    }

    //get correct attack script
    private void TypeSwitch()
    {
        switch(_holdType)
        {
            case 0:
                _era = GetComponent<EnemyRangedAttack>();
                break;
            case 1:
                _ema = GetComponent<EnemyMeleeAttack>();
                break;
            case 2:
                _eb = GetComponent<EnemyBoss>();
                break;
            default:
                break;
        }
    }
}
