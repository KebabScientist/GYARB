using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // PlayerData for Player 1 and Player 2
    public PlayerData player1Data;
    public PlayerData player2Data;

    public int dropdownSelection;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            player1Data = new PlayerData("Player 1");
            player2Data = new PlayerData("Player 2");
            DontDestroyOnLoad(gameObject);
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

    public void SetDropdownValue(int value)
    {
        dropdownSelection = value;

        // Log the value for testing purposes
        Debug.Log("Dropdown value saved: " + dropdownSelection);

        // You can use this value for other game logic here
    }

    // You can also add a method to get the saved dropdown value if needed
    public int GetDropdownValue()
    {
        return dropdownSelection;
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
