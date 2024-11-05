using UnityEngine;

public class BikeController : MonoBehaviour
{
    [Header("Bike Settings")]
    public float maxSpeed = 20f;              // Maximum forward speed
    public float acceleration = 5f;            // Acceleration rate
    public float deceleration = 5f;            // Deceleration rate
    public float turnSpeed = 50f;              // Speed at which the bike turns
    public float maxSteerAngle = 30f;          // Maximum angle for steering rotation

    [Header("Bike Components")]
    public Transform frontWheel;
    public Transform rearWheel;

    [Header("Additional Steering Parts")]
    public Transform[] steeringParts;

    private Rigidbody rb;
    private float currentSpeed = 0f;           // Current speed of the bike
    private float steeringAngle = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleSteering();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Vertical"); // Get input for forward/backward movement

        // Calculate target speed based on input
        float targetSpeed = moveInput * maxSpeed;

        // Smoothly change the current speed toward the target speed
        if (moveInput > 0) // Accelerating
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        }
        else if (moveInput < 0) // Decelerating (going backward)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, deceleration * Time.fixedDeltaTime);
        }
        else // When no input, gradually bring speed to 0
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.fixedDeltaTime);
        }

        // Apply forward or backward force to the Rigidbody
        Vector3 moveForce = transform.forward * currentSpeed;
        rb.AddForce(moveForce, ForceMode.Force);

        // Optional: Rotate rear wheel visually based on movement speed
        if (rearWheel != null)
        {
            rearWheel.Rotate(Vector3.right * currentSpeed * 10 * Time.fixedDeltaTime);
        }
    }

    private void HandleSteering()
    {
        float steerInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys

        // Calculate steering angle
        steeringAngle = steerInput * maxSteerAngle;

        // Apply turning torque to the Rigidbody
        Quaternion turnRotation = Quaternion.Euler(0f, steeringAngle, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        // Rotate the front wheel and additional parts for visual steering
        if (frontWheel != null)
        {
            frontWheel.localRotation = Quaternion.Euler(0, steeringAngle, 0);
        }

        foreach (Transform part in steeringParts)
        {
            if (part != null)
            {
                part.localRotation = Quaternion.Euler(0, steeringAngle, 0);
            }
        }
    }
}
