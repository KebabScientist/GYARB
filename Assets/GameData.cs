using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrapData
{
    public TrapType trapType;
    public string zone;

    public TrapData(TrapType trapType, string zone)
    {
        this.trapType = trapType;
        this.zone = zone;
    }
}

public static class GameData
{
    private static List<TrapData> placedTraps = new List<TrapData>();

    public static void AddTrap(TrapData trapData)
    {
        placedTraps.Add(trapData);
    }

    public static List<TrapData> GetPlacedTraps()
    {
        return new List<TrapData>(placedTraps);
    }
}
