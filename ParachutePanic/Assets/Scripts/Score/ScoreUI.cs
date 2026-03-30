using UnityEngine;
using TMPro;

/// <summary>
/// This class displays the UI of the main score.
/// As a subscriber to the "OnScoreChange" Action.
/// </summary>

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private ScoreHandler scoreSystem;

    private void OnEnable()
    {
        scoreSystem.OnScoreChange += UpdateUI;
        GameHandler.OnGameEnd += DisplayFinalScore;
    }

    private void OnDisable()
    {
        scoreSystem.OnScoreChange -= UpdateUI;
        GameHandler.OnGameEnd -= DisplayFinalScore;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = scoreSystem.Score.ToString();
    }

    private void DisplayFinalScore()
    {
        finalScoreText.text = "FINAL SCORE: " + scoreSystem.Score;
    }
}