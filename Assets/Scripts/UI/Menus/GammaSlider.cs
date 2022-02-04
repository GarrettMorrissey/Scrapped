using UnityEngine;
using UnityEngine.UI;

public class GammaSlider : MonoBehaviour
{
    private Slider _intensitySlider;
    [SerializeField] private Light[] _listOfLights = null;
    [SerializeField] private float _defaultLightValue = 2000f;

    private void Awake()
    {
        _intensitySlider = GetComponent<Slider>();
    }

    //slider function
    public void IntensitySlider()
    {
        _intensitySlider.onValueChanged.AddListener(delegate { ChangeIntensity(); });
    }

    //changes each light in the list
    private void ChangeIntensity()
    {
        foreach(Light _currentLight in _listOfLights)
        {
            _currentLight.intensity = (_defaultLightValue * _intensitySlider.value);
        }
    }
}
