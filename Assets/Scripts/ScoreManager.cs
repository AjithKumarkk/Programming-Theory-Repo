using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreToText();
    }
    
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreToText();
    }

    public void UpdateScoreToText()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
