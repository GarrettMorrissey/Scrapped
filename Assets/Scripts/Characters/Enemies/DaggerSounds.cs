using UnityEngine;

public class DaggerSounds : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _daggerAttack = null, _daggerFootSteps = null, _daggerGrunt = null, _daggerDamaged = null;

    public void DaggerAttackSoundPlay()
    {
        _daggerAttack.Post(gameObject);
    }

    public void DaggerFootStepPlay()
    {
        _daggerFootSteps.Post(gameObject);
    }

    public void DaggerGruntPlay()
    {
        _daggerGrunt.Post(gameObject);
    }

    public void DaggerDamagedPlay()
    {
        _daggerDamaged.Post(gameObject);
    }
}
