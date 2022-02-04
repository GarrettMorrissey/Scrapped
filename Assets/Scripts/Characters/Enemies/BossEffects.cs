using UnityEngine;

public class BossEffects : MonoBehaviour
{
    [SerializeField] private GameObject _coinExplosion = null, _effectSpawn = null;

    public void CoinExplosionEffectCall()
    {
        Instantiate(_coinExplosion, _effectSpawn.transform.position, Quaternion.identity);
    }
}
