using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 1.5f;
    public bool _spawnedWillPatrol = false;
    private bool _atMax = false;
    [SerializeField] private float _patrolDistance = 1f;
    [HideInInspector] public Vector3 _spawnedLocation;

    //sets the enemy's route
    public void Patrol()
    {
        if (_spawnedWillPatrol == false)
        {
            return;
        }
        if (_atMax == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(_spawnedLocation.x + _patrolDistance, _spawnedLocation.y, _spawnedLocation.z), 
                Time.deltaTime * _enemySpeed);
            if(transform.position.x > _spawnedLocation.x + _patrolDistance)
            {
                _atMax = true;
                Debug.Log("atMax");
            }
        }
        else if (_atMax)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(_spawnedLocation.x - _patrolDistance, _spawnedLocation.y, _spawnedLocation.z),
                Time.deltaTime * _enemySpeed);
            if (transform.position.x < _spawnedLocation.x - _patrolDistance)
            {
                _atMax = false;
                Debug.Log("atmin");
            }
        }
    }
}
