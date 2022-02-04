using System.Collections;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private bool _canShoot = true;
    [SerializeField] private float _startTimeBetweenShots = 0;
    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private GameObject _powerBullet = null;
    private Camera _mainCamera;
    [SerializeField] private Transform _firePoint = null;

    [SerializeField] private GameObject _vfx = null;

    private PlayerHealth _ph;
    private Animator _anim;
    private int _fullPlayerHealth = 3;
    public int _damageControl = 1;

    private void Awake()
    {
        _ph = GetComponentInParent<PlayerHealth>();
        _mainCamera = Camera.main;
        _anim = transform.parent.parent.GetComponentInChildren<Animator>();
    }

    //holds main functions for shooting
    public void HandleShooting()
    {
        LookAtMouse();
        Fire();
    }

    //spawns the _bullet
    private void Fire()
    {
        if (_canShoot == true)
            StopCoroutine("ShotDelay");

        if (Input.GetMouseButtonDown(0) && _canShoot == true)
        {
            MuzzleVFX();
            if (Time.timeScale == 0)
                return;
            if(CheckIfPowered())
            {
                GameObject _bullet = Instantiate(_powerBullet, _firePoint.position, transform.parent.rotation);
                PlayerBullet _pb = _bullet.GetComponent<PlayerBullet>();
                _pb._damageMultiplier = _damageControl;
            }
            else
            {
                Instantiate(_bullet, _firePoint.position, transform.parent.rotation);
                PlayerBullet _pb = _bullet.GetComponent<PlayerBullet>();
                _pb._damageMultiplier = _damageControl;
            }
            _canShoot = false;
            _anim.SetTrigger("Shooting");
            StartCoroutine("ShotDelay");
        }
    }

    private bool CheckIfPowered()
    {
        _fullPlayerHealth = _ph._ratioControl;
        if (_ph._currentHealth >= 45)
            return true;
        else
            return false;
    }

    //lets player aim
    private void LookAtMouse()
    {
        Vector3 _direction = Input.mousePosition - _mainCamera.WorldToScreenPoint(transform.parent.position);
        float _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
    }

    //controls rate of fire
    IEnumerator ShotDelay()
    {
        yield return new WaitForSeconds(_startTimeBetweenShots);
        _canShoot = true;
    }

    public void MuzzleVFX() {       
        //muzzle when shooting
        Instantiate(_vfx, transform.position, transform.rotation);
    }
}
