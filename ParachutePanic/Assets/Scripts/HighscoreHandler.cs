using System.Collections;
using System.Collections.Generic;
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
    
    [SerializeField] private int maxCount = 10;
    [SerializeField] private string filename;
    private List<HighscoreElement> highscoreList = new List<HighscoreElement>();

    private void Start()
    {
        LoadHighscores();
    }

    private void LoadHighscores()
    {
        highscoreList = FileHandler.ReadListFromJSON<HighscoreElement>(filename);

        while (highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }

        onHighscoreListChanged?.Invoke(highscoreList);
    }

    private void SaveHighscore()
    {
        FileHandler.SaveToJSON<HighscoreElement>(highscoreList, filename);
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
}