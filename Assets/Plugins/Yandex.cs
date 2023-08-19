using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();
    [DllImport("__Internal")]
    private static extern void GiveMeUserInfo();


    [DllImport("__Internal")]
    private static extern void AdvByRewards();

    [DllImport("__Internal")]
    private static extern void ShowAdv();
    public static Yandex instance;
    public Action<bool> OnShowAdvReward;
    public Action<bool> onShowFullscreenAdv;
    public Action onAddReward;
    //public static bool audioPlay;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
           

        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        
        Debug.Log("yan start method");
    }



    //нажимаю на кнопку
    public void ShowAdvButton()
    {
        AdvByRewards();
        
    }
    //добавил награду
    public void AddReward()
    {

        onAddReward?.Invoke();
    }
    //видео с рекламой закрывается
    public void CloseAdvReward()
    {
        OnShowAdvReward?.Invoke(false);
        
    }
    public void StartVideoAdvReward()
    {
        OnShowAdvReward?.Invoke(true);
        
    }
   
    public  void ShowAdvBetweenScenes()
    {
        SoundSystem.isShowAdv = true;
        ShowAdv();
    }

    public void OnOpenAdvFullscreen()
    {
        //audioPlay = false;
          onShowFullscreenAdv?.Invoke(true);
        SoundSystem.isShowAdv = true;
        Debug.Log("adv open ============================================= true");
    }

   public void OnCloseAdvFullscreen()
    {
        //audioPlay = true;
        SoundSystem.isShowAdv = false;
        onShowFullscreenAdv?.Invoke(false);
      
        Debug.Log("adv open ============================================== false");
    }

    // Update is called once per frame
    public void HelloButton()
    {
        //Hello();//приветствие
        //GiveMeUserInfo();//авторизация
    }



}
