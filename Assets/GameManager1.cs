using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance; 

    private string lastCheckpoint;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }

        lastCheckpoint = PlayerPrefs.GetString("LastCheckpoint", "Checkpoint1");
    }

    public void SetCheckpoint(string checkpointName)
    {
        lastCheckpoint = checkpointName;
        PlayerPrefs.SetString("LastCheckpoint", checkpointName);
    }

    public string GetLastCheckpoint()
    {
        return lastCheckpoint;
    }

    public void ResetCheckpoint()
    {
        lastCheckpoint = "Checkpoint1";
        PlayerPrefs.SetString("LastCheckpoint", lastCheckpoint);
    }
}