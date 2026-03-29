using System;
using UnityEngine;
using UnityEngine.Events;

public class ScoreHandler : MonoBehaviour
{
    public int Score { get; private set; }
    
    [SerializeField] private int score;
    public Action OnScoreChange;
    
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