using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;
    public float xAxis, GasInput, BreakInput;
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private float isBreaking;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 0f;
    public float Try = -.9f;
    bool reverse = false;
    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0,Try,0);
    }

    private void FixedUpdate()
    {

        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = xAxis;
        verticalInput = GasInput;
        isBreaking = BreakInput;
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput/32767;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        brakeForce = isBreaking;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

void Update()
    {
         if( Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                    reverse =true;
                }
                else{
                    reverse = false;
                }
        if(LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);
            xAxis = rec.lX;

            if(rec.lY > 0)
            {
                GasInput = 0;
            }
            else if(rec.lY < 0)
            { 
               if(reverse)
               {
                GasInput = rec.lY / -32768f;
               }
            else{
                    GasInput = rec.lY / 32768f;
            }
                
            }

            if(rec.lRz > 0)
            {
                BreakInput = 0;
            }else if(rec.lRz < 0)
            {
                BreakInput = rec.lRz / -32768f;
            }
        }
    }
}


