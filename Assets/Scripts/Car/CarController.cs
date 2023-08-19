using System;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using VContainer;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [SerializeField] private float forceTorque, steerAngle, brakeForce;
    [SerializeField] private int indexCar;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private WheelCollider[] wheelColliders;
    [SerializeField] private Transform[] wheelTransforms;
    [SerializeField,Min(1)] private float nitroCoefficient = 2f;


    private MobileController mobileController;

    [SerializeField] private ParticleSystem nitroEffect;
    private float vertical, horizontal;
    public  Wheel Wheel;
    public int CarIndex => indexCar;
    private float torque, steer, brake;

    public bool IsNitro { get; private set; }
    //public float HeightCar { get { return heightCar; } }
    //public bool isDrive { get; set; }
    //private UnityEngine.Quaternion startRotation;
    private LevelService levelService;
   
    private float preNitro;
    public void Init(LevelService levelService)
    {
       
        this.mobileController = levelService.MobileController;
        Wheel = new Wheel(wheelColliders, wheelTransforms);
        this.levelService = levelService;
        preNitro = forceTorque;
        ShowNitro(false);
        torque = steer = 0;
        if (Application.isMobilePlatform == false)
        {
            if (mobileController.gameObject.activeSelf)
            {
                mobileController.gameObject.SetActive(false);
            }

        }

    }
    private void FixedUpdate()
    {
        if (levelService.StartRace == false) { Wheel.BrakeTorque(10000); return; }

        Wheel.InputVertical(torque);
        Wheel.InputHorizontal(steer);
        Wheel.BrakeTorque(brake);
        Wheel.ShowWheelTransform();
      
    }

    private void Update()
    {
        vertical = 0;
        horizontal = 0;
        if (Application.isMobilePlatform == false)
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

        }
        else
        {
            if (mobileController.DownPress) vertical = -1;
            if (mobileController.UpPress) vertical = 1;
            if (mobileController.LeftPress) horizontal = -1;
            if (mobileController.RightPress) horizontal = 1;
            if (mobileController.StopPress)
            {
                brake = brakeForce;
                torque = 0;
            }

            if (mobileController.NitroPress && IsNitro == false)
            {
                Wheel.ApplyNitro(nitroCoefficient, true);
                IsNitro = true;
                ShowNitro(IsNitro);
            }
            else if (mobileController.NitroPress == false && IsNitro == true)
            {
                Wheel.ApplyNitro(nitroCoefficient, false);
                IsNitro = false;
                ShowNitro(IsNitro);
            }

        }

        torque = vertical * Time.deltaTime * forceTorque;
        steer = horizontal * steerAngle;
        Debug.Log(Wheel.GetRpm());

        if (Input.GetKey(KeyCode.Space) )
        {
            brake = brakeForce;
            torque = 0;
        }
        else if ((int)vertical != 0)
        {
            brake = 0;
        }
        if (vertical == 0 && brake < brakeForce)
        {
            brake += Time.deltaTime * brakeForce;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Wheel.ApplyNitro(nitroCoefficient, true);
            IsNitro = true;
            ShowNitro(IsNitro);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Wheel.ApplyNitro(nitroCoefficient, false);
            IsNitro = false;
            ShowNitro(IsNitro);
        }
     
        //SmoothBrake();
    }

     

    private void ShowNitro(bool isNitro)
    {
        nitroEffect.gameObject.SetActive(isNitro);
        if (isNitro)
        {
         
            forceTorque = forceTorque + 20000;
        }
        else
            forceTorque = preNitro;
    }
}