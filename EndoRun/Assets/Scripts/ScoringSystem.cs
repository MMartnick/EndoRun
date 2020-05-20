using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static int score;
    public static int updateScore;
    public static int previousScore;

    private void Start()
    {
        score = previousScore;
    }

    void Update()
    {
        score = score + updateScore;
        scoreText.GetComponent<Text>().text = "Score: " + score;
        updateScore = 0;
    }
}
