using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nextSceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}