using UnityEngine;

public class AKWwiseManager : MonoBehaviour
{
    private static AKWwiseManager _akWwiseManager;

    private void Awake()
    {
        if(_akWwiseManager == null)
        {
            _akWwiseManager = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
