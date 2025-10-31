using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This class handles menu navigation w/ controller support.
/// This goes for Pausing/Unpausing, and the GameOverMenu specifically.
/// </summary>

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu, goMenu; // go = GameOver abbreviated
    public GameObject pauseFirstButton, goFirstButton, goSecondButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Fire3"))
        {
            PauseUnpause();
        }
        
        // On a gamepad, press equivalent of X on a playstation controller
        // Once that input has been recognized, selects UI.
        if (Input.GetButtonDown("Cancel"))
        {
            GameOverResume();
        }
        
    }

    public void PauseUnpause()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            
            // Clear selected object
            EventSystem.current.SetSelectedGameObject(null);
            // Set a new selected object
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void GameOverResume()
    {
        if (!goMenu.activeInHierarchy) return;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goFirstButton);
    }

    public void BackToMainMenu()
    {
        if (!goMenu.activeInHierarchy) return;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(goSecondButton);
    }
}
