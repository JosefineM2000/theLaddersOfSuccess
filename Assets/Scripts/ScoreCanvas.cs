using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCanvas : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highText;

    public int score = 0;
    public int highscore = 0;

    private void Awake()
    {
        highscore = PlayerPrefs.GetInt("HighScore");
    }

    private void Start()
    {
        scoreText.text = score.ToString();
        highText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoints()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    public void SetHighScore()
    {
        if (score > highscore)
        {
            highscore = score;

            PlayerPrefs.SetInt("HighScore", highscore);
        }
    }
}
