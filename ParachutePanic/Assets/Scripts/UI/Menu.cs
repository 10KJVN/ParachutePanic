using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class handles menu navigation w/ controller support.
/// This goes for Pausing/Unpausing, and the GameOverMenu specifically.
/// EDIT: NO MORE CONTROLLER SUPPORT, IT'S CANCELED.
/// </summary>

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject pauseFirstButton;
    public GameObject goFirstButton;
    public GameObject goSecondButton;

    // TODO: Safeguard update() to no longer allow 
    // Game being paused while on game over screen.
    // This causes it to continue in the background.

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.P ) )
        {
            PauseUnpause();
        }
        
        if ( Input.GetButtonDown( "Cancel" ) )
        {
            GameOverResume();
        }
    }

    public void PauseUnpause()
    {
        if ( !pauseMenu.activeInHierarchy )
        {
            pauseMenu.SetActive( true );
            Time.timeScale = 0f;
            
            EventSystem.current.SetSelectedGameObject( null );
            EventSystem.current.SetSelectedGameObject( pauseFirstButton );
        }
        else
        {
            pauseMenu.SetActive( false );
            Time.timeScale = 1f;
        }
    }

    public void GameOverResume()
    {
        if ( !gameOverMenu.activeInHierarchy ) return;
        EventSystem.current.SetSelectedGameObject( null );
        EventSystem.current.SetSelectedGameObject( goFirstButton );
    }

    public void BackToMainMenu()
    {
        if ( !gameOverMenu.activeInHierarchy ) return;
        EventSystem.current.SetSelectedGameObject( null );
        EventSystem.current.SetSelectedGameObject( goSecondButton );
    }
}
