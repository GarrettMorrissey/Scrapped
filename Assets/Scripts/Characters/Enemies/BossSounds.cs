using UnityEngine;

public class BossSounds : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _bossAttack = null, _bossDying = null, _bossDamaged = null, _coinsSound = null, _laugh = null;

    public void BossAttackSoundPlay()
    {
        _bossAttack.Post(gameObject);
    }

    public void BossDyingpPlay()
    {
        _bossDying.Post(gameObject);
    }

    public void BossDamagedPlay()
    {
        _bossDamaged.Post(gameObject);
    }

    public void CoinsSoundPlay()
    {
        _coinsSound.Post(gameObject);
    }

    public void LaughSoundPlay()
    {
        _laugh.Post(gameObject);
    }
}
