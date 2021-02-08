using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public Text scoreText;
    private int totalScore = 0;

    private void Awake()
    {
        scoreText.text = "Score: " + totalScore;
    }

    public void UpdateScore(int score)
    {
        totalScore += score;
        scoreText.text = "Score: " + totalScore;
    }
}
