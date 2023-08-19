using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Button buttonSkibidyActive;
    [SerializeField] private Text skibidyText;
    [SerializeField] private List<Level> levels;
    [SerializeField] private Text score;

    public static string NameLevel;
    private void Start()
    {
        levels.ForEach(l => l.Init(score));
        score.text = ScoreCalculator.Score.ToString() + "$";
        buttonSkibidyActive.onClick.AddListener(OnClickSkibidy);


        if (Social1.PlayerPrefs.GetInt("SKIBIDY", Skibidy.SKYBIDI_ACTIVE) == 0)
        {
            skibidyText.text = "Выключить туалет";
        }
        else
        {
            Skibidy.SKYBIDI_ACTIVE = 1;
            skibidyText.text = "Включить туалет";
        }

    }
    private int countClick;
    private bool addScore;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            countClick++;
            if(countClick > 50 && addScore == false)
            {
                ScoreCalculator.Score = ScoreCalculator.Score + 10000;
                score.text = ScoreCalculator.Score.ToString() + "$";
                addScore = true;
            }
        }
    }
    private void OnClickSkibidy()
    {
        if (Social1.PlayerPrefs.GetInt("SKIBIDY", Skibidy.SKYBIDI_ACTIVE) == 0)
        {
            Skibidy.SKYBIDI_ACTIVE = 1;
            Social1.PlayerPrefs.SetInt("SKIBIDY", Skibidy.SKYBIDI_ACTIVE);
            skibidyText.text = "Включить туалет";
        }
        else
        {
            Skibidy.SKYBIDI_ACTIVE = 0;
            Social1.PlayerPrefs.SetInt("SKIBIDY", Skibidy.SKYBIDI_ACTIVE);
            skibidyText.text = "Выключить туалет";
        }
    }
}
