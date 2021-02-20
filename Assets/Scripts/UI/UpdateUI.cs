using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public Text scoreText;

    private void Awake()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
