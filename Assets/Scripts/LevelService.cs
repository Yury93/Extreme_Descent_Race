using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class LevelService : MonoBehaviour
{
    [SerializeField] private UIService uIService;
    [SerializeField] private CheckPoint[] finishes;
    [SerializeField] private DeathTrigger deathTrigger;
    [SerializeField] private Transform startTransform;
    [SerializeField] private List<CarController> cars;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera virtualCamera;
    [SerializeField] private MobileController mobileController;
    public MobileController MobileController => mobileController;
    private CarController currentCar;
    public bool StartRace { get; private set; }
    private void Start()
    {
        CarActivated(CarSelecter.CarIndex,3);
        for (int i = 0; i < finishes.Length; i++)
        {
            finishes[i].onCheckPoint += AddScore;
        }
        deathTrigger.onDeath += OnDeath;
        uIService.Init(this);
        Time.timeScale = 1;
    }
    private void CarActivated(int indexCar, int time)
    {
        foreach (CarController controller in cars)
        {
            if (controller.CarIndex == indexCar)
                continue;
            else
                Destroy(controller.gameObject);
        }
        cars.RemoveAll(controller => controller.CarIndex != indexCar);
        StartRace = false;
        currentCar = cars[0];
        cars[0].gameObject.SetActive(true);
        cars[0].Init(this);
        virtualCamera.m_Follow = cars[0].transform;
        virtualCamera.LookAt = cars[0].transform;
        Timer timer = new Timer(this, time, () =>
        {
            StartRace = true;

        });
    }

    private void OnDeath()
    {
      uIService.ApplyFinish();
    
    }

    public void Restart()
    {
        currentCar.transform.position = startTransform.position;
        currentCar.transform.rotation = startTransform.rotation;
        CarActivated(CarSelecter.CarIndex,1);
    }

    private void AddScore(int score)
    {
        ScoreCalculator.Score = ScoreCalculator.Score + score;
        uIService.UpdateScoreTable();
    }

 
}
