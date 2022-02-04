using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades_VFX : MonoBehaviour
{
    private bool grappleActive = false;
    private bool bashActive = false;

    [SerializeField]
    private float _deathTimer = 5f;

    [Header("Upgrades VFX")]
    [SerializeField]
    private GameObject _grappleVFX = null;
    [SerializeField]
    private GameObject _bashVFX = null;

    [Header("Upgrade")]
    [SerializeField]
    private UpgradeStatus _upgradeStatus = null;

    private void Update()
    {
        if(_upgradeStatus._currentGrappleAmount >= 3 && grappleActive == false)
        {
            GrappleVFX();
            grappleActive = true;
        }

        if(_upgradeStatus._currentBashAmount >= 3 && bashActive == false)
        {
            BashVFX();
            bashActive = true;
        }
    }

    private void GrappleVFX(){
        GameObject grapple = Instantiate(_grappleVFX, transform.position, _grappleVFX.transform.rotation, gameObject.transform);
        Destroy(grapple, _deathTimer);
    }
    
    private void BashVFX(){
        GameObject bash = Instantiate(_bashVFX, transform.position, _bashVFX.transform.rotation, gameObject.transform);
        Destroy(bash, _deathTimer);
    }
}
