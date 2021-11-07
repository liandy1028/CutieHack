using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{

    public int highScore;
    string highScoreKey = "HighScore";

    public Text Leaderbored;

    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        //use this value in whatever shows the leaderboard.
    }

    void Update()
    {
        Leaderbored.text = "HighScore: " + highScore.ToString();
    }



}