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

            Rigidbody playerRigidbody = GetPlayerRigidbody(playerIndex);
            if (playerRigidbody != null)
            {
                AdjustVelocity(playerRigidbody, checkpointMode);
            }
        }

        if (other.CompareTag("P2"))
        {
            playerIndex = 2;
            // Get the mode from the GameManager based on the dropdown value
            checkpointMode = GameManager.Instance.GetDropdownValue(dropdownIndex);

            // Set the checkpoint for the player
            GameManager.Instance.SetCheckpoint(playerIndex, checkpointName);
            Debug.Log("Player " + playerIndex + " reached checkpoint: " + checkpointName + " - " + GetModeName(checkpointMode));

            Rigidbody playerRigidbody = GetPlayerRigidbody(playerIndex);
            if (playerRigidbody != null)
            {
                AdjustVelocity(playerRigidbody, checkpointMode);
            }



        }
    }

    private Rigidbody GetPlayerRigidbody(int playerIndex)
    {
        GameObject playerObject = null;
        if (playerIndex == 1)
        {
            playerObject = GameObject.FindWithTag("P1");  // Find Player 1
        }
        else if (playerIndex == 2)
        {
            playerObject = GameObject.FindWithTag("P2");  // Find Player 2
        }

        if (playerObject != null)
        {
            return playerObject.GetComponent<Rigidbody>();  // Return the Rigidbody of the player
        }
        else
        {
            Debug.LogError("Player with index " + playerIndex + " not found!");
            return null;  // Return null if the player isn't found
        }
    }

    private void AdjustVelocity(Rigidbody playerRigidbody, int mode)
    {
        switch (mode)
        {
            case 0: // Nothing
                
                playerRigidbody.velocity = playerRigidbody.velocity; // No change
                break;
            case 1: // SpeedBoost
                
                playerRigidbody.velocity *= 1.5f; 
                Debug.Log("SpeedBoost applied!");
                break;
            case 2: 
                
                playerRigidbody.velocity *= 0.5f; 
                Debug.Log("SlowDown applied!");
                break;
            case 3: // OilSpill
                
                playerRigidbody.velocity *= 0.3f; 
                Debug.Log("OilSpill applied!");
                break;
            default:
                Debug.LogWarning("Unknown mode: " + mode);
                break;
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
