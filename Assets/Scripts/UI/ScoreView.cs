using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreView : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _ball.ScoreChanged += OnScoreChange;
    }
    private void OnDisable()
    {
        _ball.ScoreChanged -= OnScoreChange;
    }

    private void OnScoreChange(int score)
    {
        _text.text = score.ToString();
    }
}
