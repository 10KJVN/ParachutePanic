using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public int Score { get; private set; }

    [SerializeField] private int score;

    public void IncrementScore(int amount)
    {
        score += amount;
    }

    public void DecrementScore(int amount)
    {
        score -= amount;
    }
}