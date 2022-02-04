using UnityEngine;

public class BasePickup : MonoBehaviour
{

    public void HandlePSM(Collider2D _object)
    {
        _object.GetComponent<PlayerCharacter>()._pickupsCollected++;
    }
}
