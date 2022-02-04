using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private float _delay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RemoveFromScene", _delay);
    }

    //so scene doesn't get filled with empty effects
    private void RemoveFromScene()
    {
        Destroy(gameObject);
    }
}
