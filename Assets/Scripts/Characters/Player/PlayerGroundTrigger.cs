using UnityEngine;

public class PlayerGroundTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask = default;
    [SerializeField] private Vector2 _offset = default;
    [SerializeField] private float _radius = 0.5f;
    
    private bool _triggered;

    private void Update()
    {
        Vector2 center = (Vector2)transform.position + _offset;
        _triggered = Physics2D.OverlapCircle(center, _radius, _groundMask);
    }

    public bool ReturnJumpBool()
    {
        return _triggered;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position + (Vector3)_offset, _radius);
    }

}
