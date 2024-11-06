using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public string checkpointName; // Unique name for the checkpoint
    private int playerIndex; // 1 &2

    public int checkpointMode;

    private void OnTriggerEnter(Collider other)
    {
        // Only trigger if the collider is a player
        if (other.CompareTag("P1"))
        {
            playerIndex = 1;
            // Set the checkpoint for the player (based on the playerIndex)
            GameManager.Instance.SetCheckpoint(playerIndex, checkpointName);
            Debug.Log("Player " + playerIndex + " reached checkpoint: " + checkpointName + " - " + GetModeName(checkpointMode));
        }

        if (other.CompareTag("P2"))
        {
            playerIndex = 2;
            // Set the checkpoint for the player (based on the playerIndex)
            GameManager.Instance.SetCheckpoint(playerIndex, checkpointName);
            Debug.Log("Player " + playerIndex + " reached checkpoint: " + checkpointName + " - " + GetModeName(checkpointMode));
        }
    }

    private string GetModeName(int mode)
    {
        switch (mode)
        {
            case 0:
                return "Nothing";
            case 1:
                return "SpeedBoost";
            case 2:
                return "SlowDown";
            case 3:
                return "OilSpill";
            default:
                return "Unknown";
        }
    }
}
