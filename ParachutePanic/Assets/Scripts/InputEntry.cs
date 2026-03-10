using System;

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