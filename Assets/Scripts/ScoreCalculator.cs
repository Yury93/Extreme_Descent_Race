using UnityEngine;

public static class ScoreCalculator
{
    public static int Score
    {
        get
        {
            return PlayerPrefs.GetInt("Score");
        }
        set
        {
            PlayerPrefs.SetInt("Score", value);
        }
    }
}
