using UnityEngine;
using TMPro;

public class PlayerStatsMenu : MonoBehaviour
{

    private PlayerHealth _ph;
    private PlayerMovement _pm;
    private PlayerBash _pb;
    private MainCameraMovement _mcm;
    private PlayerWeapon _pw;
    private PlayerCharacter _pc;
    private GameObject _player;
    [SerializeField] private TMP_Text[] _texts = null;
    [SerializeField] private TMP_Text[] _statTexts = null;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _ph = _player.GetComponent<PlayerHealth>();
        _pm = _player.GetComponent<PlayerMovement>();
        _pb = _player.GetComponent<PlayerBash>();
        _mcm = Camera.main.GetComponent<MainCameraMovement>();
        _pw = _player.GetComponentInChildren<PlayerWeapon>();
        _pc = _player.GetComponent<PlayerCharacter>();
        IntializeTexts();
    }

    //puts the text at starting variables
    private void IntializeTexts()
    {
        IntStatTexts(_texts, _statTexts, 0, _ph._currentHealth, "PlayerHP: ");
        FloatStatTexts(_texts, _statTexts, 1, _pm._statsMenuMultipler, "MoveSpeed: ");
        FloatStatTexts(_texts, _statTexts, 2, _pm._extraHeight, "ExtraHeight: ");
        FloatStatTexts(_texts, _statTexts, 3, _pb._bashSpeedMultipler, "BashForce: ");
        FloatStatTexts(_texts, _statTexts, 4, _mcm._zOffset, "CameraDistance: ");
        FloatStatTexts(_texts, _statTexts, 5, _mcm._fovVariable, "CameraFOV: ");
        FloatStatTexts(_texts, _statTexts, 6, _mcm._yOffset, "CameraY: ");
        IntStatTexts(_texts, _statTexts, 7, _pw._damageControl, "Damage: ");
        FloatStatTexts(_texts, _statTexts, 8, _pb._timeBetweenBash, "BashCooldown: ");
        IntStatTexts(_texts, _statTexts, 9, _pc._pickupsCollected, "PickupsFound: ");
    }

    #region Hp +/-
    public void IncreaseHP()
    {
        if (_ph._currentHealth < 250)
        {
            _ph.IncreaseMaxHP();
            IntStatTexts(_texts, _statTexts, 0, _ph._currentHealth, "PlayerHP: ");
        }
    }

    public void DecreaseHP()
    {
        if(_ph._currentHealth > 25)
        {
            _ph.DecreaseMaxHP();
            IntStatTexts(_texts, _statTexts, 0, _ph._currentHealth, "PlayerHP: ");
        }
    }

    #endregion

    #region MoveSpeed +/-
    public void IncreaseSpeed()
    {
        if(_pm._statsMenuMultipler < 2f)
        {
            _pm._statsMenuMultipler += 0.25f;
            FloatStatTexts(_texts, _statTexts, 1, _pm._statsMenuMultipler, "MoveSpeed: ");
        }
    }

    public void DecreaseSpeed()
    {
        if (_pm._statsMenuMultipler > 0.25f)
        {
            _pm._statsMenuMultipler -= 0.25f;
            FloatStatTexts(_texts, _statTexts, 1, _pm._statsMenuMultipler, "MoveSpeed: ");
        }
    }

    #endregion

    #region JumpHeight +/-
    public void IncreaseJump()
    {
        if (_pm._extraHeight < 2f)
        {
            _pm._extraHeight += 0.25f;
            FloatStatTexts(_texts, _statTexts, 2, _pm._extraHeight, "ExtraHeight: ");
        }
    }

    public void DecreaseJump()
    {
        if (_pm._extraHeight > 0.25f)
        {
            _pm._extraHeight -= 0.25f;
            FloatStatTexts(_texts, _statTexts, 2, _pm._extraHeight, "ExtraHeight: ");
        }
    }

    #endregion

    #region Bash +/-
    public void IncreaseBash()
    {
        if(_pb._bashSpeedMultipler < 2f)
        {
            _pb._bashSpeedMultipler += 0.25f;
            FloatStatTexts(_texts, _statTexts, 3, _pb._bashSpeedMultipler, "BashForce: ");
        }
    }

    public void DecreaseBash()
    {
        if (_pb._bashSpeedMultipler > 0.25f)
        {
            _pb._bashSpeedMultipler -= 0.25f;
            FloatStatTexts(_texts, _statTexts, 3, _pb._bashSpeedMultipler, "BashForce: ");
        }
    }

    #endregion

    #region CameraDistance +/-
    public void IncreaseCameraDistance()
    {
        if(_mcm._zOffset < 35f)
        {
            _mcm._zOffset += 5f;
            FloatStatTexts(_texts, _statTexts, 4, _mcm._zOffset, "CameraDistance: ");
        }
    }

    public void DecreaseCameraDistance()
    {
        if (_mcm._zOffset > 5f)
        {
            _mcm._zOffset -= 5f;
            FloatStatTexts(_texts, _statTexts, 4, _mcm._zOffset, "CameraDistance: ");
        }
    }

    #endregion

    #region CameraFOV +/-
    public void IncreaseCameraFOV()
    {
        if (_mcm._fovVariable < 150f)
        {
            _mcm._fovVariable += 10f;
            FloatStatTexts(_texts, _statTexts, 5, _mcm._fovVariable, "CameraFOV: ");
        }
    }

    public void DecreaseCameraFOV()
    {
        if (_mcm._fovVariable > 20f)
        {
            _mcm._fovVariable -= 10f;
            FloatStatTexts(_texts, _statTexts, 5, _mcm._fovVariable, "CameraFOV: ");
        }
    }

    #endregion

    #region CameraY-Offset +/-
    public void IncreaseCameraY()
    {
        if (_mcm._yOffset < 2f)
        {
            _mcm._yOffset += 0.25f;
            FloatStatTexts(_texts, _statTexts, 6, _mcm._yOffset, "CameraY: ");
        }
    }

    public void DecreaseCameraY()
    {
        if (_mcm._yOffset > 0.25f)
        {
            _mcm._yOffset -= 0.25f;
            FloatStatTexts(_texts, _statTexts, 6, _mcm._yOffset, "CameraY: ");
        }
    }

    #endregion

    #region Damage +/-
    public void IncreaseDamage()
    {
        if(_pw._damageControl < 4)
        {
            _pw._damageControl++;
            IntStatTexts(_texts, _statTexts, 7, _pw._damageControl, "Damage: ");
        }
    }

    public void DecreaseDamage()
    {
        if (_pw._damageControl > 1)
        {
            _pw._damageControl--;
            IntStatTexts(_texts, _statTexts, 7, _pw._damageControl, "Damage: ");
        }
    }

    #endregion

    #region BashCooldown +/-
    public void IncreaseBashCooldown()
    {
        if (_pb._timeBetweenBash < 4f)
        {
            _pb._timeBetweenBash += 0.25f;
            FloatStatTexts(_texts, _statTexts, 8, _pb._timeBetweenBash, "BashCooldown: ");
        }
    }

    public void DecreaseBashCooldown()
    {
        if (_pb._timeBetweenBash > 0.25f)
        {
            _pb._timeBetweenBash -= 0.25f;
            FloatStatTexts(_texts, _statTexts, 8, _pb._timeBetweenBash, "BashCooldown: ");
        }
    }

    #endregion

    #region Pickups number

    public void PickupTexts()
    {
        IntStatTexts(_texts, _statTexts, 9, _pc._pickupsCollected, "PickupsFound: ");
    }

    #endregion

    private void IntStatTexts(TMP_Text[] _textTMP, TMP_Text[] _statTextTMP, int _index, int _intStat, string _name)
    {
        _textTMP[_index].text = _intStat.ToString();
        _statTextTMP[_index].text = _name + _intStat.ToString();
    }

    private void FloatStatTexts(TMP_Text[] _textTMP, TMP_Text[] _statTextTMP, int _index, float _floatStat, string _name)
    {
        _textTMP[_index].text = _floatStat.ToString();
        _statTextTMP[_index].text = _name + _floatStat.ToString();
    }
}
