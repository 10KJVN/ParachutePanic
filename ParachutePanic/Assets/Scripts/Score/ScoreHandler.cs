using System;
using UnityEngine;

/// <summary>
/// This class manages the main Score.
/// It enables other classes to add or decrease it,
/// to which it listens to notify the ScoreUI class.
/// </summary>

public class ScoreHandler : MonoBehaviour
{
    public int Score { get; private set; }
    public Action OnScoreChange;
    
    [SerializeField] private int score;
    
    public void IncrementScore(int amount)
    {
        score += amount;
        Score = score;
        OnScoreChange?.Invoke();
    }

    public void DecrementScore(int amount)
    {
        score -= amount;
        Score = score;
        OnScoreChange?.Invoke();
    }
}