using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public string checkpointName;  // Unique name for the checkpoint
    private int playerIndex;  // 1 & 2
    private int checkpointMode;

    public int dropdownIndex;  // Dropdown index to retrieve the mode (can be set in the inspector)

    private void OnTriggerEnter(Collider other)
    {
        // Only trigger if the collider is a player
        if (other.CompareTag("P1"))
        {
            playerIndex = 1;
            // Get the mode from the GameManager based on the dropdown value
            checkpointMode = GameManager.Instance.GetDropdownValue(dropdownIndex);

            // Set the checkpoint for the player
            GameManager.Instance.SetCheckpoint(playerIndex, checkpointName);
            Debug.Log("Player " + playerIndex + " reached checkpoint: " + checkpointName + " - " + GetModeName(checkpointMode));
        }

        if (other.CompareTag("P2"))
        {
            playerIndex = 2;
            // Get the mode from the GameManager based on the dropdown value
            checkpointMode = GameManager.Instance.GetDropdownValue(dropdownIndex);

            // Set the checkpoint for the player
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
