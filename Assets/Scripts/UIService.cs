using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

public class UIService : MonoBehaviour
{
    [Serializable]
    public class PauseMode
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Button continueButton,menuButton;
        [SerializeField] private Text score;
        public void Init()
        {
            continueButton.onClick.AddListener(() =>  ApplyPause(false));
            menuButton.onClick.AddListener(() =>
            {
                Debug.Log("MAIN");
                SceneManager.LoadScene("SelectLevel");
            });
        }
        public void ApplyPause(bool active)
        {
            canvas.gameObject.SetActive(active);
            if (active)
            {
                Time.timeScale = 0.01f;
                score.text = ScoreCalculator.Score.ToString() + "$"; ;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }

    [Serializable]
    public class FinishLevel
    {
        [SerializeField] private GameObject  finishCanvas;
        [SerializeField] private GameObject controllerCanvas;
        [SerializeField] private Button menuButton;
        [SerializeField] private Text scoreText;

        public void Init()
        {
            menuButton.onClick.AddListener(() => SceneManager.LoadScene("SelectLevel"));
        }
        public void ApplyFinish()
        {
            finishCanvas.gameObject.SetActive(true);
            controllerCanvas.gameObject.SetActive(false);
            scoreText.text = ScoreCalculator.Score.ToString();
        }
    }
    [SerializeField] private FinishLevel finishLevel;
    [SerializeField] private PauseMode pauseMode;
    [SerializeField] private Button restartButton,pauseButton;
    [SerializeField] private Text scoreText;
    public Button RestartButton => restartButton;
 
    public void Init(LevelService levelService)
    {
        finishLevel.Init();
        pauseMode.Init();
        UpdateScoreTable();
        restartButton.onClick.AddListener(levelService.Restart);
        pauseButton.onClick.AddListener(()=>pauseMode.ApplyPause(true));
    }
    public void UpdateScoreTable()
    {
        scoreText.text = ScoreCalculator.Score.ToString() + "$";
    }
    public void ApplyFinish()
    {
        finishLevel.ApplyFinish();
    }

}
