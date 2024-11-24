using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlTest1 : MonoBehaviour
{
    private float horizontalInput1, verticalInput1;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Settings
    [SerializeField] public float motorForce, breakForce, maxSteerAngle;
    [SerializeField] private float brakeSmoothing = 5f;
    [SerializeField] private float accelerationSmoothing = 5f;


    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    [Range(0, 5f)]
    public float forwardGrip = 1.5f; // Adjust this to increase/decrease forward grip
    [Range(0f, 5f)]
    public float sidewaysGrip = 1.5f; // Adjust this to increase/decrease sideways grip

    private void FixedUpdate() {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        AdjustWheelGrip1();
    }



    private void AdjustWheelGrip1()
    {
        // Set initial grip settings for each wheel
        AdjustWheelGrip(frontLeftWheelCollider, forwardGrip, sidewaysGrip);
        AdjustWheelGrip(frontRightWheelCollider, forwardGrip, sidewaysGrip);
        AdjustWheelGrip(rearLeftWheelCollider, forwardGrip, sidewaysGrip*0.75f);
        AdjustWheelGrip(rearRightWheelCollider, forwardGrip, sidewaysGrip*0.75f);
    }

    private void GetInput()
    {
        // Reset inputs
        horizontalInput1 = 0f;
        verticalInput1 = 0f;

        // Steering Input
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput1 = -1f; // Turn left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput1 = 1f; // Turn right
        }

        // Acceleration and Braking Input
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput1 = 1f; // Move forward
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput1 = -1f; // Move backward
        }

        // Breaking Input
       // isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        // Smooth acceleration
        float targetMotorTorque = verticalInput1 * motorForce;
        rearLeftWheelCollider.motorTorque = Mathf.Lerp(frontLeftWheelCollider.motorTorque, targetMotorTorque, Time.deltaTime * accelerationSmoothing);
        rearRightWheelCollider.motorTorque = Mathf.Lerp(frontRightWheelCollider.motorTorque, targetMotorTorque, Time.deltaTime * accelerationSmoothing);

        // Smooth braking
        float targetBrakeForce = isBreaking ? breakForce : 0f;
        currentbreakForce = Mathf.Lerp(currentbreakForce, targetBrakeForce, Time.deltaTime * brakeSmoothing);
        ApplyBreaking();
    }


    private void ApplyBreaking() {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering() {
        currentSteerAngle = maxSteerAngle * horizontalInput1;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels() {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

    private void AdjustWheelGrip(WheelCollider wheel, float forwardStiffness, float sidewaysStiffness)
    {
        // Adjust forward friction (gas/broms)
        WheelFrictionCurve forwardFriction = wheel.forwardFriction;
        forwardFriction.stiffness = forwardStiffness; // Set forward grip multiplier
        wheel.forwardFriction = forwardFriction;

        // Adjust sideways friction (styra)
        WheelFrictionCurve sidewaysFriction = wheel.sidewaysFriction;
        sidewaysFriction.stiffness = sidewaysStiffness; // Set sideways grip multiplier
        wheel.sidewaysFriction = sidewaysFriction;
    }
}
