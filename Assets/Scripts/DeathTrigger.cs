using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public Action onDeath;
    private void OnTriggerEnter(Collider other)
    {
        onDeath?.Invoke();
    }
}
