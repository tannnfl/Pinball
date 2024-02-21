using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    Ball ball;
    int score;

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        ball = GameObject.Find("ball").GetComponent<Ball>();
    }

    void Update()
    {
        if (ball != null)
        {
            score = ball.Score(); 
            scoreText.text = "Score: " + score + " R to restart";
            
        }
        
    }
}