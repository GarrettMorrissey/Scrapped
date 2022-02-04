using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int _currentHealth;
    public bool _damageSwitch = true;

    [SerializeField] private int _reducedStartingHealthBy = 70;
    [SerializeField] private int _startingHealth = 30;

    public HealthBar _healthBar;
    private MainCameraMovement _mcm;
    private PlayerCharacter _pc;
    private PlayerPosition _pp;
    private PlayerSounds _ps;
    private float _changeInHealthBarRatio;
    private float _tempHealthChange;
    public int _ratioControl;

    //VFX
    [Header("VFX")]
    [SerializeField]
    private GameObject _vfxDamage = null;


    [Header("Green Screen")]
    [SerializeField]
    private GameObject _greenScreen = null;

    private void Start()
    {
        _healthBar.SetMaxHealth(1f);
        _pp = GetComponent<PlayerPosition>();
        _pc = GetComponent<PlayerCharacter>();
        _ps = GetComponentInChildren<PlayerSounds>();
        _ratioControl = _currentHealth;
        CheckMaxHP();
        _healthBar.GetComponent<Image>().color = Color.yellow;
        _mcm = Camera.main.GetComponent<MainCameraMovement>();
        HealthBarAmount(_reducedStartingHealthBy);
        _currentHealth = _startingHealth;
        _healthBar.SetHealth(-1 * _changeInHealthBarRatio);
    }

    //check if alive after damage
    public int TakeDamage(int damage)
    {
        if(_damageSwitch == true)
        {
            _currentHealth -= damage;
            _mcm.StartShake();
            HealthBarAmount(damage);
            _healthBar.SetHealth(-1 * _changeInHealthBarRatio);
            _ps.DamageSoundPlay();
        }

        HealthColorChange();
        HurtVFX();



        if (_currentHealth <= 0)
        {
            PlayerDie();
        }
        return _currentHealth;
    }

    //reloads scene on death
    private void PlayerDie()
    {
        GetComponentInChildren<PlayerSounds>().DyingSoundPlay();
        gameObject.SetActive(false);
        _pp.CallReload();
    }

    //called when healed
    public int RecoverHP(int _heal)
    {
        
        //for edge case if triggered more than once
        if (_currentHealth == _ratioControl)
        {

            return _currentHealth;
        }

        _currentHealth += _heal;
        HealthBarAmount(_heal);
        _healthBar.SetHealth(_changeInHealthBarRatio);
        _pc._changeInPlayerHP = _heal;
        _pc._healed = true;
        return _currentHealth;
    }

    //called by statsmenu
    #region statsmenu +/-
    
    public void IncreaseMaxHP()
    {
        _ratioControl += 25;
        CheckMaxHP();
    }

    public void DecreaseMaxHP()
    {
        _ratioControl -= 25;
        CheckMaxHP();
    }
    #endregion

    #region CheckMaxHP
    //checks max HP setting
    private void CheckMaxHP()
    {
        switch(_ratioControl)
        {
            case 25:
                _currentHealth = 25;
                break;
            case 50:
                _currentHealth =50;
                break;
            case 75:
                _currentHealth = 75;
                break;
            case 100:
                _currentHealth = 100;
                break;
            case 125:
                _currentHealth = 125;
                break;
            case 150:
                _currentHealth = 150;
                break;
            case 175:
                _currentHealth = 175;
                break;
            case 200:
                _currentHealth = 200;
                break;
            case 225:
                _currentHealth = 225;
                break;
            case 250:
                _currentHealth = 250;
                break;
            default:
                break;
        }
    }
    #endregion

    //this will guide how much the health bar changes
    private void HealthBarAmount(int _incomingSource)
    {
        _tempHealthChange = _incomingSource;
        _changeInHealthBarRatio = _tempHealthChange / _ratioControl;
    }

#region VFX
public void HurtVFX() {
        //engranes explode when hurt
        Instantiate(_vfxDamage, transform.position, transform.rotation);
    }



#endregion


#region healthbar color
    private void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Toxic"))
        {
            _healthBar.GetComponent<Image>().color = Color.green;
            _greenScreen.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        HealthColorChange();
        _greenScreen.SetActive(false);
    }

    private void HealthColorChange()
    {
        //change color when damage:
        if (_currentHealth <= 25)
        {
            //change color when damage
            _healthBar.GetComponent<Image>().color = Color.red;
        }
        else if (_currentHealth <= 40)
        {
            _healthBar.GetComponent<Image>().color = new Color32(240, 153, 11, 255);
        }
        else
        {
            _healthBar.GetComponent<Image>().color = Color.yellow;
        }
    }
#endregion
}
