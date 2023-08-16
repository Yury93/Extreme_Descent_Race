using System;
using System.Collections; 
using UnityEngine;

public class Timer  
{
    public float Sec { get; private set; }
    public bool End { get; private set; }
    private Coroutine coroutine;
    private MonoBehaviour mono;
    public Timer(MonoBehaviour mono,int sec, Action onAction = null)
    {
        End = false;
        Sec = sec;
        this.mono = mono;
       coroutine =  this. mono.StartCoroutine(CorTimer(onAction));
    }
    public void StopTimer()
    {
        this.mono.StopCoroutine(coroutine);
    }
    IEnumerator CorTimer(Action onAction = null)
    {
        yield return new WaitForSecondsRealtime(Sec);
        Sec = 0;
        onAction?.Invoke();
        End = true;
    }
}
