using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlTest2 : MonoBehaviour
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

    private void FixedUpdate() {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        // Reset inputs
        horizontalInput1 = 0f;
        verticalInput1 = 0f;

        // Steering Input
        // Use Left and Right Arrow keys for steering
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput1 = -1f; // Steer left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput1 = 1f; // Steer right
        }

        // Acceleration and Braking Input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalInput1 = 1f; // Move forward
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput1 = -1f; // Move backward
        }

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.PageUp);
    }

    private void HandleMotor()
    {
        // Smooth acceleration
        float targetMotorTorque = verticalInput1 * motorForce;
        frontLeftWheelCollider.motorTorque = Mathf.Lerp(frontLeftWheelCollider.motorTorque, targetMotorTorque, Time.deltaTime * accelerationSmoothing);
        frontRightWheelCollider.motorTorque = Mathf.Lerp(frontRightWheelCollider.motorTorque, targetMotorTorque, Time.deltaTime * accelerationSmoothing);

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
}