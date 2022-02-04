using UnityEngine;
using UnityEngine.UI;

enum VolumeSliders
{
    MASTER,
    MUSIC,
    SFX,
    AMBIENCE
}

public class MainMusicVolumeControl : MonoBehaviour
{
    private Slider _volumeSlider;
    //[SerializeField] private int _whichSlider;
    [SerializeField] private VolumeSliders _volumeSliderNumber = default;

    private void Awake()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    //slider function
    public void VolumeSlider()
    {
        _volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
    }

    //changes selected volume
    private void ChangeVolume()
    {
        float _volume = _volumeSlider.value;
        switch (_volumeSliderNumber)
        {
            case VolumeSliders.MASTER:
                AkSoundEngine.SetRTPCValue("MasterVolume", _volume);
                break;
            case VolumeSliders.MUSIC:
                AkSoundEngine.SetRTPCValue("MusicVolume", _volume);
                break;
            case VolumeSliders.SFX:
                AkSoundEngine.SetRTPCValue("SFXVolume", _volume);
                break;
            case VolumeSliders.AMBIENCE:
                //TODO AkSoundEngine.SetRTPCValue("AmbienceVolume", _volume);
                break;
            default:
                break;
        }
    }
}
