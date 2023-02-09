using System;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private float score = 0;
    private bool isPlaying = true;

    private void Update()
    {
        if (isPlaying)
        {
            score += Time.deltaTime * scoreMultiplier;
            scoreText.text = Mathf.FloorToInt(score).ToString();    
        }
    }

    public int GetScoreOnGameEnd()
    {
        isPlaying = false;
        scoreText.text = string.Empty;
        return Mathf.FloorToInt(score);
    }
}
