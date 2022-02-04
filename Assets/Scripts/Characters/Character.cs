using UnityEngine;

public class Character : MonoBehaviour
{

    //this will be overrided for movement
    public virtual void CharacterMovement()
    {

    }

    //this will be overrided for when health is changed
    public virtual void CharacterChangedHealth()
    {

    }

    //this will be overrided for attacks
    public virtual void CharacterAttack()
    {

    }

    private void Update()
    {
        CharacterAttack();
        CharacterMovement();
        CharacterChangedHealth();
    }
}
