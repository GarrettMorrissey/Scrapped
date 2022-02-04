using UnityEngine;

public class AkEventHelper : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event wwiseEvent;
    public AK.Wwise.Event WwiseEvent { get; private set; }
    public void Post() => wwiseEvent.Post(gameObject);
    public void Post(GameObject go) => wwiseEvent.Post(go);
}
