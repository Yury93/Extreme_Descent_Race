using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    [SerializeField] private EventButton up,down,right,left, nitro,stop;
    public bool UpPress { get { return up.buttonPressed; } }
    public bool DownPress { get { return down.buttonPressed; } }
    public bool LeftPress { get { return left.buttonPressed; } }
    public bool RightPress { get { return right.buttonPressed; } }
    public bool NitroPress { get { return nitro.buttonPressed; } }
    public bool StopPress { get { return stop.buttonPressed; } }
 
}
