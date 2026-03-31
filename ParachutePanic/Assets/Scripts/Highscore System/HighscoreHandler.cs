using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This class manages the new Highscore System.
/// By writing/reading to .JSON files utilizing
/// The FileHandler.cs functionalities.
/// </summary>

public class HighscoreHandler : MonoBehaviour
{
    public delegate void OnHighscoreListChanged(List<HighscoreElement> list);
    public static event OnHighscoreListChanged onHighscoreListChanged;

    public delegate void OnHighscoresLoaded(int highscore);
    public static event OnHighscoresLoaded onHighscoresLoaded;
    
    [SerializeField] private int maxCount = 10;
    [SerializeField] private string filename;
    private List<HighscoreElement> highscoreList = new();
    private int highestScore;

    private void Start()
    {
        LoadHighscores();
    }

    private void LoadHighscores()
    {
        highscoreList = FileHandler.ReadListFromJSON<HighscoreElement>(filename);

        if (highscoreList == null || !highscoreList.Any())
        {
            Debug.Log("The list is either null or empty.");
            return;
        }
        
        Debug.Log("The list contains elements.");
        highestScore = highscoreList![0].points;
        
        while (highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }

        onHighscoreListChanged?.Invoke(highscoreList);
    }

    private void SaveHighscore()
    {
        FileHandler.SaveToJSON(highscoreList, filename);
    }

    public void AddHighscoreIfPossible(HighscoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= highscoreList.Count || element.points >= highscoreList[i].points)
            {
                // add new high score
                highscoreList.Insert(i, element);

                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                SaveHighscore();
                onHighscoreListChanged?.Invoke(highscoreList);
                break;
            }

        }
    }
    
    public void GetHighestScoreAvailable()
    {
        Debug.Log($"Highest score found: " + highestScore);
        onHighscoresLoaded?.Invoke(highestScore);
    }
}