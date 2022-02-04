using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    [SerializeField]
    private int _backBtn = 2;

    [Header("Buttons Unchecked")]
    [SerializeField]
    private GameObject _btnAmateurUnchecked = null;
    [SerializeField]
    private GameObject _btnCollabUnchecked = null;
    [SerializeField]
    private GameObject _btnThanksUnchecked = null;

    [Header("Buttons In Use")]
    [SerializeField]
    private GameObject _btnAmateurUsing = null;
    [SerializeField]
    private GameObject _btnCollabUsing = null;
    [SerializeField]
    private GameObject _btnThanksUsing = null;

    [Header("Views")]
    [SerializeField]
    private GameObject _amateursView = null;
    [SerializeField]
    private GameObject _collabsView = null;
    [SerializeField]
    private GameObject _thanksView = null;
    [SerializeField]
    private GameObject _moreViewTeam = null;
    [SerializeField]
    private GameObject _moreViewCollabs = null;

    public void AmateurHoursPressed() {

        //Views AMATEUR
        _amateursView.SetActive(true);
        _collabsView.SetActive(false);
        _thanksView.SetActive(false);
        _moreViewTeam.SetActive(false);
        _moreViewCollabs.SetActive(false);

        //Blue Btns
        _btnAmateurUnchecked.SetActive(false);
        _btnCollabUnchecked.SetActive(true);
        _btnThanksUnchecked.SetActive(true);

        //Yellow Btns
        _btnAmateurUsing.SetActive(true);
        _btnCollabUsing.SetActive(false);
        _btnThanksUsing.SetActive(false);
    }

    public void CollabsPressed(){

        //Views COLLABS
        _collabsView.SetActive(true);
        _amateursView.SetActive(false);
        _thanksView.SetActive(false);
        _moreViewTeam.SetActive(false);
        _moreViewCollabs.SetActive(false);

        //Blue Btns
        _btnCollabUnchecked.SetActive(false);
        _btnAmateurUnchecked.SetActive(true);
        _btnThanksUnchecked.SetActive(true); 

        //Yellow Btns
        _btnAmateurUsing.SetActive(false);
        _btnCollabUsing.SetActive(true);
        _btnThanksUsing.SetActive(false);
    }

    public void ThanksPressed(){

        //Views THANKS
        _thanksView.SetActive(true);
        _amateursView.SetActive(false);
        _collabsView.SetActive(false);
        _moreViewTeam.SetActive(false);
        _moreViewCollabs.SetActive(false);

        //Blue Btns
        _btnAmateurUnchecked.SetActive(true);
        _btnCollabUnchecked.SetActive(true);
        _btnThanksUnchecked.SetActive(false);

        //Yellow Btns
        _btnAmateurUsing.SetActive(false);
        _btnCollabUsing.SetActive(false);
        _btnThanksUsing.SetActive(true);
    }

    public void MoreAboutTeam() {
        _moreViewTeam.SetActive(true);
        _amateursView.SetActive(false);
        _thanksView.SetActive(false);
        _amateursView.SetActive(false);
        _collabsView.SetActive(false);

        //Blue Btns
        // _btnAmateurUnchecked.SetActive(false);
        // _btnCollabUnchecked.SetActive(false);
        // _btnThanksUnchecked.SetActive(false);

        //Yellow Btns
        _btnAmateurUsing.SetActive(true);
        _btnCollabUsing.SetActive(false);
        _btnThanksUsing.SetActive(false);
    }

    public void MoreAboutCollabs(){
        _moreViewCollabs.SetActive(true);
        _collabsView.SetActive(false);
        _thanksView.SetActive(false);
        _amateursView.SetActive(false);
        _collabsView.SetActive(false);

        //Blue Btns
        // _btnAmateurUnchecked.SetActive(false);
        // _btnCollabUnchecked.SetActive(false);
        // _btnThanksUnchecked.SetActive(false);

        //Yellow Btns
        _btnAmateurUsing.SetActive(false);
        _btnCollabUsing.SetActive(true);
        _btnThanksUsing.SetActive(false);
    }

    public void BackToTeam(){
        // _moreViewTeam.SetActive(false);
        // _amateursView.SetActive(true);
        AmateurHoursPressed();
    }

    public void BackToCollabs(){
        // _moreViewCollabs.SetActive(false);
        // _collabsView.SetActive(true);
        CollabsPressed();
    }

    public void BackbuttonPressed()
    {
        //Main menu
        SceneManager.LoadScene(_backBtn);
    }
}
