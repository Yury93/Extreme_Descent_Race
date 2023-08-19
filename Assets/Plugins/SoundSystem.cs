using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [System.Serializable]
    public class SoundLibrary
    {
        
    }
    public static SoundSystem instance;
    
    public SoundLibrary soundLibrary;
    [SerializeField] private Sound soundPrefab;
    [SerializeField] private AudioSource backgroundAudioSource;
    
    //public AudioListener audioListener;
    public  bool isAudioPlay;
    public static bool isShowAdv;
    private void Start()
    {
        InitSingleton();

    }
  public void OffShowAdv()
    {
        isShowAdv = false;
        SetActiveSound(true);
    }
    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            if (isShowAdv == false)
                isAudioPlay = true;

        }
        else
        {
            Destroy(gameObject);
        }
        Yandex.instance.onShowFullscreenAdv += OnShowFullScreenADV;
        SetActiveSound(true);
    }

    public void OnShowFullScreenADV(bool active)
    {
        if (active == true)
        {
            isShowAdv = true;
            SetActiveSound(false);
            Debug.Log("method STOP audio");
        }
        if (active == false)
        {
            isShowAdv = false;
            SetActiveSound(true);
            Debug.Log("method PLAY audio");
        }
    }
  
    public void SetActiveSound(bool active)
    {
       
        isAudioPlay = active;
        if(isAudioPlay == false || isShowAdv == true)
        {
            backgroundAudioSource.enabled = false;
            backgroundAudioSource.Stop();
        }
        else
        {
            if (isShowAdv == false)
            {
               
                    backgroundAudioSource.enabled = true;
                    backgroundAudioSource.Play();

            }
        }
    }
    public void CreateSound(AudioClip audioClip)
    {
        if (isAudioPlay)
        {
            var sound = Instantiate(soundPrefab, transform);
            sound.PlaySound(audioClip);
            Destroy(sound.gameObject, 1f);
        }

    }
    public void CreateSound(AudioClip audioClip, float startTime,float volume)
    {
        if (isAudioPlay && isShowAdv == false)
        {
            var sound = Instantiate(soundPrefab, transform);

            sound.AudioSource.clip = audioClip;
            sound.AudioSource.volume = volume;
            int startSample = (int)(startTime * audioClip.frequency);
            sound.AudioSource.timeSamples = startSample;
            //audioSource.Play();

            sound.PlaySound(sound.AudioSource.clip);
        }

    }
    public void CreateSound(AudioClip audioClip, float startTime)
    {
        if (isAudioPlay && isShowAdv == false)
        {
            var sound = Instantiate(soundPrefab, transform);

            sound.AudioSource.clip = audioClip;
            int startSample = (int)(startTime * audioClip.frequency);
            sound.AudioSource.timeSamples = startSample;
            //audioSource.Play();

            sound.PlaySound(sound.AudioSource.clip);
        }

    }
    public void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SetActiveSound(false);
        }
        else if ( isShowAdv == false)
        {
  
            SetActiveSound(true);
        }
    }
    public void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            SetActiveSound(false);
        }
        else if (isShowAdv == false)
        {
            SetActiveSound(true);
        } 
    }
   
}
