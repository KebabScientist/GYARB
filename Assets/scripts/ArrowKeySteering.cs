using UnityEngine;

public class ArrowKeySteering : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Left and Right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // Up and Down arrow keys

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
