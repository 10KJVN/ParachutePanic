using System;

/// <summary>
/// A serializable data container class.
/// Holds the players' name & points per entry.
/// </summary>

[Serializable]
public class HighscoreElement
{
    public string playerName;
    public int points;

    public HighscoreElement (string name, int points)
    {
        playerName = name;
        this.points = points;
    }
    
}
