using UnityEngine;

public class ScoreTracker : Singleton<ScoreTracker>
{
    public int score;
    public int highScore;
    
    protected override void Awake()
    {
        base.Awake();
        highScore = 0;
        score = 0;
        DontDestroyOnLoad(gameObject);
    }

    public void TryMutateHighscore()
    {
        if (score > highScore) highScore = score;
        score = 0;
    }
}
