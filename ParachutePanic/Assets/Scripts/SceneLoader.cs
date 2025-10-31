using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    public string currentSceneName;

    public void Awake()
    {
       currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void Start()
    {
        print(currentSceneName);
        Time.timeScale = 1;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneName);
    }
}