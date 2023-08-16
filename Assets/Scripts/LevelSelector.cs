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


        if (PlayerPrefs.GetInt("SKIBIDY", Skibidy.SKYBIDI_ACTIVE) == 0)
        {
            skibidyText.text = "Выключить туалет";
        }
        else
        {
            Skibidy.SKYBIDI_ACTIVE = 1;
            skibidyText.text = "Включить туалет";
        }

    }

    private void OnClickSkibidy()
    {
        if (PlayerPrefs.GetInt("SKIBIDY", Skibidy.SKYBIDI_ACTIVE) == 0)
        {
            Skibidy.SKYBIDI_ACTIVE = 1;
            PlayerPrefs.SetInt("SKIBIDY", Skibidy.SKYBIDI_ACTIVE);
            skibidyText.text = "Включить туалет";
        }
        else
        {
            Skibidy.SKYBIDI_ACTIVE = 0;
            PlayerPrefs.SetInt("SKIBIDY", Skibidy.SKYBIDI_ACTIVE);
            skibidyText.text = "Выключить туалет";
        }
    }
}
