using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        pointsText.text = score.ToString() + " POINT";

        if (score > 1 || score == 0)
        {
            pointsText.text += "S";
        }
    }

    public void restartButton()
    {
        //Dependant on build index
        SceneManager.LoadScene(1);
    }

    public void menuButton()
    {
        SceneManager.LoadScene(0);
    }
}
    