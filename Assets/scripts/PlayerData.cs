using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string playerName;     
    public string lastCheckpoint; 
    public int score;             

    // Constructor
    public PlayerData(string playerName)
    {
        this.playerName = playerName;
        this.lastCheckpoint = "Start"; // Default checkpoint
        this.score = 0;               // Defaultscore
    }
}

