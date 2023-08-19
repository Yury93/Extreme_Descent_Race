using UnityEngine;

public static class ScoreCalculator
{
    public static int Score
    {
        get
        {
            return Social1.PlayerPrefs.GetInt("Score");
        }
        set
        {
            Social1.PlayerPrefs.SetInt("Score", value);
        }
    }
}
