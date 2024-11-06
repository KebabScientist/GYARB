using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Checkpoint
{
    public string checkpointID; // Unique ID for the checkpoint
    public bool isReached = false; // Status of the checkpoint (whether it’s reached or not)
}

public class CheckPointManager : MonoBehaviour
{
    // List to store checkpoints and their status, visible in the Inspector
    public List<Checkpoint> checkpoints = new List<Checkpoint>();

    // Method to mark a checkpoint as reached
    public void CheckpointReached(string checkpointID)
    {
        foreach (var checkpoint in checkpoints)
        {
            if (checkpoint.checkpointID == checkpointID && !checkpoint.isReached)
            {
                checkpoint.isReached = true; // Mark this checkpoint as reached
                Debug.Log("Checkpoint " + checkpointID + " reached!");

                // Optional: Check if all checkpoints have been reached
                if (AllCheckpointsReached())
                {
                    Debug.Log("All unique checkpoints reached! Level complete!");
                    // Trigger any level completion logic here
                }

                break; // Exit the loop once the correct checkpoint is found
            }
        }
    }

    // Method to check if all checkpoints have been reached
    private bool AllCheckpointsReached()
    {
        foreach (var checkpoint in checkpoints)
        {
            if (!checkpoint.isReached) return false; // If any checkpoint is not reached, return false
        }
        return true;
    }

    // Optional: Method to check if a specific checkpoint has been reached
    public bool IsCheckpointReached(string checkpointID)
    {
        foreach (var checkpoint in checkpoints)
        {
            if (checkpoint.checkpointID == checkpointID)
            {
                return checkpoint.isReached;
            }
        }
        return false;
    }
}
