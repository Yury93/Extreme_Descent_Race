using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private int score;
    private bool finish;
    public Action<int> onCheckPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (!finish)
        {
            onCheckPoint?.Invoke(score);
            finish = true;
        } 
    }
}
