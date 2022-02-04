using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event _footStepEvent = null, _jumpStartEvent = null, _jumpEndEvent = null, 
        _bashStartEvent = null, _grappleOn = null, _grappleOff = null, _dyingSound = null, _damageSound = null,
        _grappleUpgraded = null, _bashUpgraded = null, _grappleWhoosh = null;

    public void FootStepSoundPlay()
    {
        _footStepEvent.Post(gameObject);
    }

    public void JumpSoundPlay()
    {
        _jumpStartEvent.Post(gameObject);
    }

    public void LandingStart()
    {
        _jumpEndEvent.Post(gameObject);
    }

    public void BashSoundStart()
    {
        _bashStartEvent.Post(gameObject);
    }

    public void GrappleSoundOn()
    {
        _grappleOn.Post(gameObject);
    }

    public void GrappleSoundOff()
    {
        _grappleOff.Post(gameObject);
    }

    public void DyingSoundPlay()
    {
        _dyingSound.Post(gameObject);
    }

    public void DamageSoundPlay()
    {
        _damageSound.Post(gameObject);
    }

    public void GrapppleUpgradedPlay()
    {
        _grappleUpgraded.Post(gameObject);
    }

    public void BashUpgradedPlay()
    {
        _bashUpgraded.Post(gameObject);
    }

    public void GrappleWhooshPlay()
    {
        _grappleWhoosh.Post(gameObject);
    }
}
