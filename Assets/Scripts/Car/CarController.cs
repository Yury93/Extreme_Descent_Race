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
    [SerializeField] private int indexCar;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private WheelCollider[] wheelColliders;
    [SerializeField] private Transform[] wheelTransforms;
    [SerializeField,Min(1)] private float nitroCoefficient = 2f;
    [SerializeField] private float forceTorque, steerAngle, brakeForce, heightCar;

    [SerializeField] private ParticleSystem nitroEffect;
    private float vertical, horizontal;
    public  Wheel Wheel;
    public int CarIndex => indexCar;
    private float torque, steer, brake;
    public bool IsNitro { get; private set; }
    public float HeightCar { get { return heightCar; } }
    public bool isDrive { get; set; }
    //private UnityEngine.Quaternion startRotation;
    private LevelService levelService;


    public void Init(LevelService levelService)
    {
        Wheel = new Wheel(wheelColliders, wheelTransforms);
        this.levelService = levelService;
        ShowNitro(false);
        torque = steer = 0;
        //startRotation = transform.rotation;
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

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        torque = vertical * Time.deltaTime * forceTorque;
        steer = horizontal * steerAngle;

        if (Input.GetKey(KeyCode.Space))
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
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
           Wheel.ApplyNitro(nitroCoefficient,true);
            IsNitro = true;
            ShowNitro(IsNitro);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Wheel.ApplyNitro(nitroCoefficient, false);
            IsNitro = false;
            ShowNitro(IsNitro);
        }
       
    }

    private void ShowNitro(bool isNitro)
    {
        nitroEffect.gameObject.SetActive(isNitro);
    }
}