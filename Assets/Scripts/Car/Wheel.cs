using Unity.VisualScripting;
using UnityEngine;

public class Wheel
{

    private WheelCollider[] wheelColliders;
    private Transform[] wheelTransforms;
    private int countWheelIsGround;
    public bool IsGround { get; private set; }
    
    public Wheel(WheelCollider[] wheelColliders, Transform[] wheelTransforms)
    {
        this.wheelColliders = wheelColliders;
        this.wheelTransforms = wheelTransforms;
    }

    public void InputHorizontal(float horizontal)
    {
        wheelColliders[0].steerAngle = horizontal;
        wheelColliders[1].steerAngle = wheelColliders[0].steerAngle;
    }

    public void InputVertical(float vertical)
    {
        if ((int)vertical != 0)
        {
            for (int i = 0; i < wheelColliders.Length; i++)
            {
                wheelColliders[i].motorTorque = vertical;
            }
        }

    }
    public void ShowWheelTransform()
    {
        int countWheelIsGround = 0;
        for (int i = 0; i < wheelTransforms.Length; i++)
        {
            Vector3 wheelPosition;
            Quaternion wheelRotation;
            wheelColliders[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelTransforms[i].position = wheelPosition;
            wheelTransforms[i].rotation = wheelRotation;
            if (wheelColliders[i].isGrounded)
            {
                countWheelIsGround++;
            }
        }
        if (countWheelIsGround == 0)
        {
            IsGround = true;
        }
        else
        {
            IsGround = false;
        }
    }
    public void BrakeTorque(float brakeForce)
    {
        if (brakeForce > 1)
        {
            foreach (var wheel in wheelColliders)
            {
                wheel.brakeTorque = brakeForce;
            }
        }
        else
        {
            foreach (var wheel in wheelColliders)
            {
                wheel.brakeTorque = 0;
            }
        }
    }

    public void ApplyNitro(float nitroCoefficient,bool nitro)
    {

        if (nitro)
        {
            for (int i = 0; i < wheelColliders.Length; i++)
            {
                WheelFrictionCurve frictionCurve = wheelColliders[i].sidewaysFriction;

                frictionCurve.stiffness *= nitroCoefficient;
                wheelColliders[i].sidewaysFriction = frictionCurve;
                wheelColliders[i].forwardFriction = frictionCurve;
            }
        }
        else
        {
            for (int i = 0; i < wheelColliders.Length; i++)
            {
                WheelFrictionCurve frictionCurve = wheelColliders[i].sidewaysFriction;

                frictionCurve.stiffness = 1;
                wheelColliders[i].sidewaysFriction = frictionCurve;
                wheelColliders[i].forwardFriction = frictionCurve;
            }
        }
    }
}