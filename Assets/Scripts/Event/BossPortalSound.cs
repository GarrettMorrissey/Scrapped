using UnityEngine;

public class BossPortalSound : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event _bossPortalSoundPlay = null;

    private void Awake()
    {
        _bossPortalSoundPlay.Post(gameObject);
    }
}
