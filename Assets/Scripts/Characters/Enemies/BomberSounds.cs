using UnityEngine;

public class BomberSounds : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _bomberAttack = null, _bomberFootSteps = null, _bomberDamaged = null, _bomberDying = null;

    public void BomberAttackSoundPlay()
    {
        _bomberAttack.Post(gameObject);
    }

    public void BomberFootStepPlay()
    {
        _bomberFootSteps.Post(gameObject);
    }

    public void BomberDamagedPlay()
    {
        _bomberDamaged.Post(gameObject);
    }

    public void BomberDyingPlay()
    {
        _bomberDying.Post(gameObject);
    }
}
