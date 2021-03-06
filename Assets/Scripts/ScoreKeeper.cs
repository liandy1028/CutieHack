using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper scoreKeeper;
    public int score = -1;
    public int highScore = 0;
    string highScoreKey = "HighScore";

    public Text guiText;
    public Text highScoreText;

    [ContextMenu("Reset highscore")]
    void ResetHighscore()
    {
        PlayerPrefs.SetInt(highScoreKey, 0);
        PlayerPrefs.Save();
    }
    void Awake()
    {
        scoreKeeper = this;
    }

    void Start()
    {
        //Get the highScore from player prefs if it is there, 0 otherwise.
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        IncrementScore();
        highScoreText.text = "High Score: " + highScore;
    }

    public void IncrementScore()
    {
        score++;
        CheckForHighScore();
        guiText.text = "Score: " + score.ToString();
    }

    void OnDisable()
    {

        //If our scoree is greter than highscore, set new higscore and save.
        CheckForHighScore();
    }

    void CheckForHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: "+score;
        }
    }
}
