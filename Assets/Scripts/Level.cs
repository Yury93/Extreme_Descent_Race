using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class Level : MonoBehaviour
{
    public enum StateLevel { open,close }
    [SerializeField] private Image backImage;
    [SerializeField] private string nameLevel;
    [SerializeField] private int cost;
    [SerializeField] StateLevel state;
    [SerializeField] private Button button;
    [SerializeField] private Image fade;
    [SerializeField] private Text costText;
    private Text scoreText;
    private int openedLevel;
    internal void Init(Text score)
    {
        scoreText = score;
        button.onClick.AddListener(() =>
        {
            OnClick();
        });
        CheckStateLevel();
        ShowState();
    }

    private void CheckStateLevel()
    {
        openedLevel = Social1.PlayerPrefs.GetInt(nameLevel);

        if (openedLevel == 1 || nameLevel == "0")
        {
            state = StateLevel.open;
        }
        else
        {
            state = StateLevel.close;
        }
    }

    private void OnClick()
    {
        if (state == StateLevel.open)
        {
            LoadScene();
        }
        else
        {
            Buy();
        }
        CheckStateLevel();
        ShowState();
    }
    [ContextMenu("ShowState")]
    public void ShowState()
    {
        if (state == StateLevel.open)
        {
            costText.text = "";
            fade.enabled = false;
        }
        else
        {
            costText.text = cost.ToString()+"$";
            fade.enabled = true;
        }
        scoreText.text = ScoreCalculator.Score.ToString() + "$";
    }

    private void LoadScene()
    {
        StartCoroutine(CorLoad());
        IEnumerator CorLoad()
        {
            backImage.color = Color.green;
            LevelSelector.NameLevel = nameLevel;
            yield return null;
            SceneManager.LoadScene("SelectCar");
        }
      
    }

    public void Buy()
    {
        if (ScoreCalculator.Score >= cost)
        {
            Social1.PlayerPrefs.SetInt(nameLevel, 1);
            state = StateLevel.open;
            ScoreCalculator.Score = ScoreCalculator.Score - cost;
        }
        ShowState();
    }
}
