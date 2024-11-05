using UnityEngine;

public class WASDSteering : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // A and D keys
        float moveVertical = Input.GetAxis("Vertical"); // W and S keys

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
