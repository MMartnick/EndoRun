using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public static int score;
    public static int updateScore;

    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        score = score + updateScore;
        scoreText.GetComponent<Text>().text = "Score: " + score;
        updateScore = 0;
    }
}
