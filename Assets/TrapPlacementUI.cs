using UnityEngine;

public class TrapPlacementUI : MonoBehaviour
{
    public TrapManager trapPlacementManager;

    public void OnTrapButtonClicked(int trapIndex, int zoneIndex)
    {
        // Safely cast the trapIndex to the TrapType enum
        TrapType trapType = (TrapType)trapIndex;
        string zone = zoneIndex == 0 ? "Zone1" : "Zone2";
        trapPlacementManager.PlaceTrap(trapType, zone);
        Debug.Log($"Trap button clicked: {trapType} for {zone}");
    }
}
