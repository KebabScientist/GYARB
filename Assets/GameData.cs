using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrapData
{
    public TrapType trapType;
    public string zone;

    public TrapData(TrapType type, string zone)
    {
        trapType = type;
        this.zone = zone;
    }
}

public static class GameData
{
    private static List<TrapData> placedTraps = new List<TrapData>();

    public static void AddTrap(TrapData trap)
    {
        placedTraps.Add(trap);
    }

    public static List<TrapData> GetPlacedTraps()
    {
        return placedTraps;
    }
}
