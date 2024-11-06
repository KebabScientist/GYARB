using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public string checkpointName; // Unique name for the checkpoint
    private int playerIndex; // 1 &2

    private void OnTriggerEnter(Collider other)
    {
        // Only trigger if the collider is a player
        if (other.CompareTag("P1"))
        {
            playerIndex = 1;
            // Set the checkpoint for the player (based on the playerIndex)
            GameManager.Instance.SetCheckpoint(playerIndex, checkpointName);
            Debug.Log("Player " + playerIndex + " reached checkpoint: " + checkpointName);
        }

        if (other.CompareTag("P2"))
        {
            playerIndex = 2;
            // Set the checkpoint for the player (based on the playerIndex)
            GameManager.Instance.SetCheckpoint(playerIndex, checkpointName);
            Debug.Log("Player " + playerIndex + " reached checkpoint: " + checkpointName);
        }
    }
}
