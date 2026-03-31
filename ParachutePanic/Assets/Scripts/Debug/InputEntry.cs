using System;

/// <summary>
/// Serializable 'data container' for an entry,
/// Test out for yourself in the jsonScene
/// </summary>

[Serializable]
public class InputEntry
{
    public string playerName;
    public int points;

    // ctor
    public InputEntry (string name, int points)
    {
        playerName = name;
        this.points = points;
    }
}