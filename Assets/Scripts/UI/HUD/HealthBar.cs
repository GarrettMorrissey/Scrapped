using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthbar = null;
    [SerializeField] private string _RTPCValue = "Dexter_Health";
    private float _value;

    //Fills bar at start
    public void SetMaxHealth(float _currentHealth)
    {
        _healthbar.fillAmount = _currentHealth;
        AkSoundEngine.SetRTPCValue(_RTPCValue, 1);
    }

    //changes the health bar when player's health changes
    public void SetHealth(float _currentHealth)
    {
        _healthbar.fillAmount += _currentHealth;
        //this changes the bullet sounds
        _value = _healthbar.fillAmount;
        AkSoundEngine.SetRTPCValue(_RTPCValue, _value);
    }
}
