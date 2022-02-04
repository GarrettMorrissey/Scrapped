using UnityEngine;
using UnityEngine.UI;

public class UpgradeStatus : MonoBehaviour
{
    [SerializeField] private GameObject _grappleIcon = null;
    [SerializeField] private GameObject _bashIcon = null;
    private GameObject _playerReference;
    private PlayerMovement _pm;
    private PlayerGrapple _pg;
    private PlayerBash _pb;
    private PlayerSounds _ps;
    private CheckPointHandler _cph;
    [SerializeField] private int _pickupAmount = 3;
    [HideInInspector] public int _currentGrappleAmount = 0, _currentBashAmount = 0;
    [HideInInspector] public bool _grappleDebug = false, _bashDebug = false;

    private void Start()
    {
        _playerReference = GameObject.FindGameObjectWithTag("Player");
        _pm = _playerReference.GetComponent<PlayerMovement>();
        _pg = _playerReference.GetComponent<PlayerGrapple>();
        _pb = _playerReference.GetComponent<PlayerBash>();
        _ps = _playerReference.GetComponentInChildren<PlayerSounds>();
        _cph = GameObject.FindGameObjectWithTag("CheckPointHandler").GetComponent<CheckPointHandler>();
        CheckPointValueCheck(_cph._grappleStatus, true);
        CheckPointValueCheck(_cph._bashStatus, false);
    }

    //control for linked buttons
    public void IconSwitch(int _whichIcon)
    {
        switch (_whichIcon)
        {
            case 2:
                GrappleSwitch();
                break;
            case 3:
                BashJumpSwitch();
                break;
            default:
                break;
        }
    }

    //on/off for grapple
    private void GrappleSwitch()
    {
        if (_grappleIcon.activeInHierarchy && _grappleDebug == true)
        {
            _grappleIcon.SetActive(false);
            _pg._grappleSwitch = false;
            _grappleDebug = false;
        }
        else
        {
            GrappleIconStatus();
        }
    }

    //on/off for bash
    private void BashJumpSwitch()
    {
        if (_bashIcon.activeInHierarchy && _bashDebug == true)
        {
            _bashIcon.SetActive(false);
            _pb._bashSwitch = false;
            _bashDebug = false;
        }
        else
        {
            BashIconStatus();
        }
    }

    //handles pickuping up grapplepickups
    private void GrappleIconStatus()
    {
        if (_grappleIcon.activeInHierarchy == false)
        {
            _grappleIcon.SetActive(true);
        }
        _currentGrappleAmount++;
        _cph._grappleStatus = _currentGrappleAmount;
        FillAmountSwitch(_grappleIcon, _cph._grappleStatus);
        if (_currentGrappleAmount >= _pickupAmount)
        {
            _pg._grappleSwitch = true;
            _ps.GrapppleUpgradedPlay();
        }
    }

    //handles pickuping up bashpickups
    private void BashIconStatus()
    {
        if (_bashIcon.activeInHierarchy == false)
        {
            _bashIcon.SetActive(true);
        }
        _currentBashAmount++;
        _cph._bashStatus = _currentBashAmount;
        FillAmountSwitch(_bashIcon, _cph._bashStatus);
        if (_currentBashAmount >= _pickupAmount)
        {
            _pb._bashSwitch = true;
            _ps.BashUpgradedPlay();
        }
    }

    private void FillAmountSwitch(GameObject _imageToFill, int _input)
    {
        switch (_input)
        {
            case 1:
                _imageToFill.GetComponent<Image>().fillAmount = 0.3f;
                break;
            case 2:
                _imageToFill.GetComponent<Image>().fillAmount = 0.6f;
                break;
            case 3:
                _imageToFill.GetComponent<Image>().fillAmount = 1f;
                break;
            default:
                break;
        }
    }

    private void CheckPointValueCheck(int value, bool _isGrapple)
    {
        if(_isGrapple)
        {
            for (int i = 0; i < value; i++)
            {
                GrappleIconStatus();
            }
        }
        else
        {
            for (int i = 0; i < value; i++)
            {
                BashIconStatus();
            }
        }
    }
}
