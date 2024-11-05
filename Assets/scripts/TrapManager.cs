using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    // List to store placed traps
    private List<TrapData> placedTraps = new List<TrapData>();

    // Reference to trap prefabs (assign in Inspector)
    public GameObject[] trapPrefabs;

    // Selected trap type (assigned when a button is clicked)
    private GameObject selectedTrap;

    // Method to select a trap
    public void SelectTrap(int trapIndex)
    {
        if (trapIndex >= 0 && trapIndex < trapPrefabs.Length)
        {
            selectedTrap = trapPrefabs[trapIndex];
            Debug.Log("Selected Trap: " + selectedTrap.name);
        }
    }

    // Method to place a trap at a specified position
    public void PlaceTrap(Vector3 position)
    {
        if (selectedTrap != null)
        {
            // Instantiate the trap at the specified position
            GameObject trapInstance = Instantiate(selectedTrap, position, Quaternion.identity);

            // Add the trap's data to the list for later use
            placedTraps.Add(new TrapData { position = position, trapType = selectedTrap.name });

            Debug.Log("Placed Trap: " + selectedTrap.name + " at " + position);
        }
        else
        {
            Debug.LogWarning("No trap selected for placement!");
        }
    }

    // Save trap data for the racing scene
    public void SaveTraps()
    {
        GameData.traps = placedTraps;
        Debug.Log("Traps saved for next scene!");
    }
}

// Struct to hold data about each trap
[System.Serializable]
public class TrapData
{
    public Vector3 position;
    public string trapType;
}
