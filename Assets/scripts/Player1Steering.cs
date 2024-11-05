using UnityEngine;

public class Player1Steering : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left and Right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // Up and Down arrow keys

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
