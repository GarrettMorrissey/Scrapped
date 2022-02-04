using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingPage : MonoBehaviour
{

    [Header("Next - intro video")]
    [SerializeField]
    private int _indexPlay = 3;

    [Header("Next - Controls")]
    [SerializeField]
    private int _indexControls = 8;

    [Header("Next - Credits")]
    [SerializeField]
    private int _indexCredits = 7;

    public void StartGame()
    {
        //Intro video
        SceneManager.LoadScene(_indexPlay);
    }

    public void Credits()
    {
        //credits page
        SceneManager.LoadScene(_indexCredits);
    }

    public void Controls(){
        SceneManager.LoadScene(_indexControls);
    }

    public void QuitGame()
    {
        //quit app
        Application.Quit();
    }
}
