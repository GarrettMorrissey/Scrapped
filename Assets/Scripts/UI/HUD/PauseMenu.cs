using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    private int _currentSubPage;
    private static bool _onPauseScreen = true;
    public static bool _gameIsPaused = false;
    public GameObject _pauseMenuUI;
    public GameObject _optionsMenuUI;
    public GameObject _debugMenuUI;
    public GameObject _spawnMenuUI;
    public GameObject _controlMenuUI;
    public GameObject _musicMenuUI;
    public GameObject _gammaMenuUI;
    public GameObject _playerMenuUI;
    public GameObject _PlayerStatsUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_onPauseScreen == true)
            {
                if (_gameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            else
            {
                MenuSwitchControl();
            }
        }

        OpenDebugFromGame();
    }

    #region menu Resume/Pause/Quit
    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
        AkSoundEngine.SetState("Game_Flow", "GamePlay");
    }

    private void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
        AkSoundEngine.SetState("Game_Flow", "Pause");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    #region menu Options
    public void LoadOptions()
    {
        _optionsMenuUI.SetActive(true);
        _pauseMenuUI.SetActive(false);
        _onPauseScreen = false;
        _currentSubPage = 1;
    }

    public void OptionsToPause()
    {
        _pauseMenuUI.SetActive(true);
        _optionsMenuUI.SetActive(false);
        _onPauseScreen = true;
        _currentSubPage = 0;
    }

    #endregion

    #region menu Debug
    public void LoadDebug()
    {
        _debugMenuUI.SetActive(true);
        _optionsMenuUI.SetActive(false);
        _currentSubPage = 2;
    }

    public void DebugToOptions()
    {
        _optionsMenuUI.SetActive(true);
        _debugMenuUI.SetActive(false);
        _currentSubPage = 1;
    }

    #endregion

    #region menu Controls
    public void LoadControls()
    {
        _controlMenuUI.SetActive(true);
        _pauseMenuUI.SetActive(false);
        _onPauseScreen = false;
        _currentSubPage = 3;
    }

    public void ControlToPause()
    {
        _pauseMenuUI.SetActive(true);
        _controlMenuUI.SetActive(false);
        _onPauseScreen = true;
        _currentSubPage = 0;
    }

    #endregion

    #region menu Spawn
    public void LoadSpawn()
    {
        _spawnMenuUI.SetActive(true);
        _debugMenuUI.SetActive(false);
        _currentSubPage = 4;
    }

    public void SpawnToDebug()
    {
        _debugMenuUI.SetActive(true);
        _spawnMenuUI.SetActive(false);
        _currentSubPage = 2;
    }

    #endregion

    #region menu Music
    public void LoadMusic()
    {
        _musicMenuUI.SetActive(true);
        _optionsMenuUI.SetActive(false);
        _currentSubPage = 5;
    }

    public void MusicToOptions()
    {
        _optionsMenuUI.SetActive(true);
        _musicMenuUI.SetActive(false);
        _currentSubPage = 1;
    }

    #endregion

    #region menu Gamma
    public void LoadGamma()
    {
        _gammaMenuUI.SetActive(true);
        _optionsMenuUI.SetActive(false);
        _currentSubPage = 6;
    }

    public void GammaToOptions()
    {
        _optionsMenuUI.SetActive(true);
        _gammaMenuUI.SetActive(false);
        _currentSubPage = 1;
    }

    #endregion

    #region menus Player
    public void LoadPlayer()
    {
        _playerMenuUI.SetActive(true);
        _debugMenuUI.SetActive(false);
        _currentSubPage = 7;
    }

    public void PlayerToDebug()
    {
        _debugMenuUI.SetActive(true);
        _playerMenuUI.SetActive(false);
        _currentSubPage = 2;
    }

    public void LoadPlayerStats()
    {
        _playerMenuUI.SetActive(false);
        _PlayerStatsUI.SetActive(true);
        _currentSubPage = 8;
    }

    public void PlayerStatsToPlayer()
    {
        _playerMenuUI.SetActive(true);
        _PlayerStatsUI.SetActive(false);
        _currentSubPage = 7;
    }

    #endregion

    //if we need to go straight to debug
    private void OpenDebugFromGame()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (_gameIsPaused == false)
            {
                Time.timeScale = 0f;
                _gameIsPaused = true;
                _debugMenuUI.SetActive(true);
                _currentSubPage = 2;
            }
            else if(_debugMenuUI.activeInHierarchy == true)
            {
                _debugMenuUI.SetActive(false);
                Time.timeScale = 1f;
                _gameIsPaused = false;
                _currentSubPage = 0;
            }
        }
    }

    //this is to handle if the player presses esc on other menus
    private void MenuSwitchControl()
    {
        switch(_currentSubPage)
        {
            case 1:
                OptionsToPause();
                break;
            case 2:
                DebugToOptions();
                break;
            case 3:
                ControlToPause();
                break;
            case 4:
                SpawnToDebug();
                break;
            case 5:
                MusicToOptions();
                break;
            case 6:
                GammaToOptions();
                break;
            case 7:
                PlayerToDebug();
                break;
            case 8:
                PlayerStatsToPlayer();
                break;
            default:
                break;
        }
    }
}
