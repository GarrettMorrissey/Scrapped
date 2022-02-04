using UnityEngine;

public class Bullet_UI : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth _playerHealth = null;

    [Header("Bullet strength")]
    [SerializeField]
    private GameObject _lowBullet = null;
    [SerializeField]
    private GameObject _strongBullet = null;

    private void Update()
    {
        if(_playerHealth._currentHealth <= 45) {
            _lowBullet.SetActive(true);
            _strongBullet.SetActive(false);
        } else {
            _lowBullet.SetActive(false);
            _strongBullet.SetActive(true);
        }
    }
}
