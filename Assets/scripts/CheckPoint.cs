using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public string checkpointID; // Unique identifier for the checkpoint
    private CheckPointManager checkpointManager;

    private void Start()
    {
        // Find the CheckPointManager in the scene
        checkpointManager = FindObjectOfType<CheckPointManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the checkpoint
        if (other.CompareTag("Player") && checkpointManager != null)
        {
            checkpointManager.CheckpointReached(checkpointID); // Notify CheckPointManager
            Debug.Log("You have reached: " + checkpointID); // Display which checkpoint you reached
        }
    }
}
