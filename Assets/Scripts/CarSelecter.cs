using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelecter : MonoBehaviour
{
    [SerializeField] private Button rightButton, leftButton, goButton;
    [SerializeField] private List<MenuCar> mCars;
    public MenuCar currentCar;
    public static int CarIndex;
    UnityEngine.AsyncOperation scene;
    private void Start()
    {
        rightButton.onClick.AddListener(() => OnClickSelectCarButton(true));
        leftButton.onClick.AddListener(()=> OnClickSelectCarButton(false));
        goButton.onClick.AddListener(LoadGame);
         
         
        RefreshButton();
        ShowCurrentCar();
         
        scene = SceneManager.LoadSceneAsync(LevelSelector.NameLevel);
        scene.allowSceneActivation = false;
       
    }

    private void LoadGame()
    {
        scene.allowSceneActivation = true;
    }

    private void OnClickSelectCarButton(bool isRightButton)
    {
        if (isRightButton)
        {
            if(CarIndex != mCars.Count + 1)
              CarIndex = CarIndex + 1;
        
        }
        else
        {
            if (CarIndex != 0)
                CarIndex = CarIndex - 1;


        }
        RefreshButton();
        ShowCurrentCar();
    }

    private void ShowCurrentCar()
    {
        foreach (var car in mCars)
        { 
            car.gameObject.SetActive(false);
        }
       currentCar =  mCars.First(c => c.CarIndex == CarIndex);
        currentCar.gameObject.SetActive(true);
        Debug.Log($"static car index {CarIndex}/ carIndex {currentCar.CarIndex}");
    }

    public void RefreshButton()
    {
        if (CarIndex == mCars.Count - 1)
            rightButton.gameObject.SetActive(false);
        else rightButton.gameObject.SetActive(true);

        if (CarIndex == 0)
            leftButton.gameObject.SetActive(false);
        else
            leftButton.gameObject.SetActive(true);
    }
}
