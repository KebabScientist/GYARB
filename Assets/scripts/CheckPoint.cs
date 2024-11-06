using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    public string checkpointName; // Unique name for the checkpoint
    public bool isReached = false; // Flag to ensure only one trigger

    // Player index to know which player triggered the checkpoint (Player 1 or Player 2)
    public int playerIndex; // 1 for Player 1, 2 for Player 2

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isReached)
        {
            isReached = true;
            GameManager.Instance.SetCheckpoint(playerIndex, checkpointName); // Notify GameManager with the player's checkpoint
            Debug.Log("Player " + playerIndex + " reached " + checkpointName);
        }
    }
}
