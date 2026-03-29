using System;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private ScoreHandler scoreSystem;

    private void OnEnable()
    {
        scoreSystem.OnScoreChange += UpdateUI;
    }

    private void OnDisable()
    {
        scoreSystem.OnScoreChange -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = scoreSystem.Score.ToString();
        //print(scoreSystem.Score);
    }
}