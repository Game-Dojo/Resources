using System;
using TMPro;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        EventManager.ScoreUpdate += OnScoreUpdate;
    }

    private void OnScoreUpdate(int totalScore)
    {
        _scoreText.text = totalScore.ToString();
    }

    private void OnDestroy()
    {
        EventManager.ScoreUpdate -= OnScoreUpdate;
    }
}