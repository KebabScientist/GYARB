using UnityEngine;
using System.Collections.Generic;

public class TrapActivator : MonoBehaviour
{
    private void Start()
    {
        List<TrapData> traps = GameData.GetPlacedTraps();
        foreach (TrapData trap in traps)
        {
            ActivateTrap(trap);
        }
    }

    private void ActivateTrap(TrapData trap)
    {
        // Implement the logic to activate the specific trap in the specified zone
        Debug.Log($"Activating {trap.trapType} in {trap.zone}");
        // Add your trap activation code here
    }
}
