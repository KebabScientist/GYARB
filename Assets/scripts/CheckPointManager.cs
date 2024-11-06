using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CheckpointManager : MonoBehaviour
{
    // Dictionary to store unique checkpoints and their states (e.g., whether they've been reached)
    private Dictionary<string, bool> checkpointsStatus = new Dictionary<string, bool>();

    // Method to register checkpoints with their unique ID
    public void RegisterCheckpoint(string checkpointID)
    {
        if (!checkpointsStatus.ContainsKey(checkpointID))
        {
            checkpointsStatus.Add(checkpointID, false); // Initialize as "not reached"
        }
    }

    // Method to mark a checkpoint as reached
    public void CheckpointReached(string checkpointID)
    {
        if (checkpointsStatus.ContainsKey(checkpointID))
        {
            checkpointsStatus[checkpointID] = true; // Mark as reached
            Debug.Log("Checkpoint " + checkpointID + " reached!");

            // Optional: Check if all checkpoints have been reached
            if (AllCheckpointsReached())
            {
                Debug.Log("All unique checkpoints reached! Level complete!");
                // Trigger any completion logic here
            }
        }
    }

    // Method to check if all checkpoints have been reached
    private bool AllCheckpointsReached()
    {
        foreach (var checkpoint in checkpointsStatus.Values)
        {
            if (!checkpoint) return false; // If any checkpoint is not reached, return false
        }
        return true;
    }

    // Method to check if a specific checkpoint has been reached
    public bool IsCheckpointReached(string checkpointID)
    {
        return checkpointsStatus.ContainsKey(checkpointID) && checkpointsStatus[checkpointID];
    }
}
