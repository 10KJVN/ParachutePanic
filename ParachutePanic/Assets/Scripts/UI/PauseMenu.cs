using UnityEngine;

/// <summary>
/// Old class used to call PauseGame
/// Currently replaced by Menu.cs
/// </summary>

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    
    private bool isPaused;

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
    }
}
