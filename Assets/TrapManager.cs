using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapManager : MonoBehaviour
{
    private TrapType selectedTrapTypeZone1;
    private TrapType selectedTrapTypeZone2;

    public void SetTrapZone1SpeedBoost()
    {
        selectedTrapTypeZone1 = TrapType.SpeedBoost;
        Debug.Log("Selected SpeedBoost for Zone 1");
    }

    public void SetTrapZone1Slowdown()
    {
        selectedTrapTypeZone1 = TrapType.Slowdown;
        Debug.Log("Selected Slowdown for Zone 1");
    }

    public void SetTrapZone1OilLeak()
    {
        selectedTrapTypeZone1 = TrapType.OilLeak;
        Debug.Log("Selected OilLeak for Zone 1");
    }

    public void SetTrapZone2SpeedBoost()
    {
        selectedTrapTypeZone2 = TrapType.SpeedBoost;
        Debug.Log("Selected SpeedBoost for Zone 2");
    }

    public void SetTrapZone2Slowdown()
    {
        selectedTrapTypeZone2 = TrapType.Slowdown;
        Debug.Log("Selected Slowdown for Zone 2");
    }

    public void SetTrapZone2OilLeak()
    {
        selectedTrapTypeZone2 = TrapType.OilLeak;
        Debug.Log("Selected OilLeak for Zone 2");
    }

    // Ensure PlaceTrap is defined and public
    public void PlaceTrap(TrapType trapType, string zone)
    {
        GameData.AddTrap(new TrapData(trapType, zone));
        Debug.Log($"Placed {trapType} in {zone}");
    }

    public void ConfirmTraps()
    {
        GameData.AddTrap(new TrapData(selectedTrapTypeZone1, "Zone1"));
        GameData.AddTrap(new TrapData(selectedTrapTypeZone2, "Zone2"));
        Debug.Log("Confirmed traps for both zones and starting race");
        SceneManager.LoadScene("Race");
    }
}
