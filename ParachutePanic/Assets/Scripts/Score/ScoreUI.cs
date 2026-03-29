using System;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private ScoreHandler scoreSystem;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = scoreSystem.Score.ToString();
        print(scoreSystem.Score);
    }
}