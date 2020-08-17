using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject highscoreText;
    public static int score;
    public static int updateScore;
    public static int previousScore;
    public static int highScore;

    private void Start()
    {
        score = previousScore;
        highScore = PlayerPrefs.GetInt("HighScore", 313);
    }

    void Update()
    {
        score = score + updateScore;
        scoreText.GetComponent<Text>().text = "Score: " + score;
        highscoreText.GetComponent<Text>().text = "High Score: " + highScore;

        updateScore = 0;

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
