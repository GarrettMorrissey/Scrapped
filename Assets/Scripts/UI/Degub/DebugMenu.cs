using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    public GameObject _fpsStatsDisplay;
    public GameObject _otherStatsDisplay;
    public GameObject _statsCanvas;
    private bool _fpsStatsSwitch = false;

    public void StatsButton()
    {
        if (_fpsStatsSwitch == false)
        {
            _statsCanvas.SetActive(true);
            _fpsStatsDisplay.SetActive(true);
            _otherStatsDisplay.SetActive(true);
            _fpsStatsSwitch = true;
        }
        else
        {
            _fpsStatsDisplay.SetActive(false);
            _otherStatsDisplay.SetActive(false);
            _statsCanvas.SetActive(false);
            _fpsStatsSwitch = false;
        }
    }
}
