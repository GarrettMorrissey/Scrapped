using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

    [Header("Next - Outro")]
    [SerializeField]
    private int _index = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Play win video scene when win
            SceneManager.LoadScene(_index);
        }
    }
}
