using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // PlayerData for Player 1 and Player 2
    public PlayerData player1Data;
    public PlayerData player2Data;

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            // Initialize PlayerData objects
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

        // Save game data after setting the checkpoint
        SaveGame();
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

    // Save game data to a file
    public void SaveGame()
    {
        string jsonPlayer1 = JsonUtility.ToJson(player1Data);
        string jsonPlayer2 = JsonUtility.ToJson(player2Data);

        // Save both players' data to individual files
        string filePathPlayer1 = Path.Combine(Application.persistentDataPath, "player1Data.json");
        string filePathPlayer2 = Path.Combine(Application.persistentDataPath, "player2Data.json");

        File.WriteAllText(filePathPlayer1, jsonPlayer1);
        File.WriteAllText(filePathPlayer2, jsonPlayer2);

        Debug.Log("Player data saved.");
    }

    // Load game data for both players
    public void LoadGame()
    {
        string filePathPlayer1 = Path.Combine(Application.persistentDataPath, "player1Data.json");
        string filePathPlayer2 = Path.Combine(Application.persistentDataPath, "player2Data.json");

        if (File.Exists(filePathPlayer1))
        {
            string jsonPlayer1 = File.ReadAllText(filePathPlayer1);
            player1Data = JsonUtility.FromJson<PlayerData>(jsonPlayer1);
            Debug.Log("Player 1 data loaded.");
        }

        if (File.Exists(filePathPlayer2))
        {
            string jsonPlayer2 = File.ReadAllText(filePathPlayer2);
            player2Data = JsonUtility.FromJson<PlayerData>(jsonPlayer2);
            Debug.Log("Player 2 data loaded.");
        }
    }
}
