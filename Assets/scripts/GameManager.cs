using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // PlayerData for Player 1 and Player 2
    public PlayerData player1Data;
    public PlayerData player2Data;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            player1Data = new PlayerData("Player 1");
            player2Data = new PlayerData("Player 2");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Set checkpoint for a specific player
    public void SetCheckpoint(int playerIndex, string checkpointName)
    {
        if (playerIndex == 1)
        {
            player1Data.lastCheckpoint = checkpointName;
        }
        else if (playerIndex == 2)
        {
            player2Data.lastCheckpoint = checkpointName;
        }

        Debug.Log("Player " + playerIndex + " reached checkpoint: " + checkpointName);
    }

    // Get the checkpoint for a specific player
    public string GetCheckpoint(int playerIndex)
    {
        if (playerIndex == 1)
        {
            return player1Data.lastCheckpoint;
        }
        else if (playerIndex == 2)
        {
            return player2Data.lastCheckpoint;
        }

        return null;
    }
}
