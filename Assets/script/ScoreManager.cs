using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int rightScore;
    public int leftScore;

    public int maxScore = 3;
    public BallControl ball;
    public void AddRightScore(int increment)
    {
        rightScore += increment;
        if (rightScore >= maxScore)
        {
            GameOver();
        }
        else
        {
            ball.ResetBall();
        }
    }

    public void AddLeftScore(int increment)
    {
        leftScore += increment;
        if (leftScore >= maxScore)
        {
            GameOver();
        }
        else 
        {
            ball.ResetBall();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
