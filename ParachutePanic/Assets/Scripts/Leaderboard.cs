using System;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private void Start()
    {
        throw new NotImplementedException();
        // GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        // int loopLength = (message.Length < names.Count) ? message.Length : names.Count;
        // Loop or iterate over the amount of names in List "names" 
        // Leaderboard ref? . GetLeaderboard ( (message) => { for (int i = 0; i < loopLength; ++i) } )
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        // Leaderboard ref
        // Assign new entry by giving username and score arguments
        // Update leaderboard, by calling Getter function
        
        // OPTIONAL: Limit the amount of characters through code - username.Substring(0, 4);
        // Or leave as is, by doing it in the inspector of input field.
        
        // Optional: if (System.Array.IndexOf (badWords, name) != -1) return;
        // Requires making my own array of bad words
     }
}
