using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public GameObject disp_Lose;
    public TextMeshProUGUI txt_Score;
    public TextMeshProUGUI txt_HighScore;
    public GameObject disp_highscoreIcon;

    void Awake()
    {
        Locator.Instance.player.OnDeath += Lose;
        Locator.Instance.player.OnPass += UpdateScore;
        UpdateScore(0);
        disp_highscoreIcon.SetActive(false);
    }

    void Lose()
    {
        disp_Lose.SetActive(true);
        ScoreTracker.Instance.TryMutateHighscore();
        txt_HighScore.text = "Highscore: " + ScoreTracker.Instance.highScore.ToString();
    }

    void UpdateScore(int score)
    {
        txt_Score.text = score.ToString();
        if(score > ScoreTracker.Instance.highScore)
            disp_highscoreIcon.SetActive(true);
    }
}
