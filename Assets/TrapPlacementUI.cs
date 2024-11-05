using UnityEngine;

public class TrapPlacementUI : MonoBehaviour
{
    public TrapManager trapPlacementManager;

    public void OnTrapButtonClicked(int trapIndex, int zoneIndex)
    {
        trapPlacementManager.PlaceTrap((TrapType)trapIndex, zoneIndex == 0 ? "Zone1" : "Zone2");
    }
}
