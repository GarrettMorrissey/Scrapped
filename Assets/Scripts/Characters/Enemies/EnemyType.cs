using UnityEngine;

public class EnemyType : MonoBehaviour
{
    [SerializeField] private int _typeOfEnemy = 0;

    //use to for EnemyCharacter to know what type of enemy this is
    public int WhichTypeOfEnemy()
    {
        return _typeOfEnemy;
    }
}
