using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skibidy : MonoBehaviour
{
    public static int SKYBIDI_ACTIVE;

    private void Start()
    {
        if(SKYBIDI_ACTIVE == 0)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
