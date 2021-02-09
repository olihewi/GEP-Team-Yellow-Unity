using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public PlayerController playerController;
    public Text scoreText;

    private void Awake()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + playerController.score;
    }
}
