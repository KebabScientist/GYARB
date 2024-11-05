using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapManager : MonoBehaviour
{
    // Button methods for Zone 1
    public void SetTrapZone1SpeedBoost()
    {
        PlaceTrap(TrapType.SpeedBoost, "Zone1");
    }

    public void SetTrapZone1Slowdown()
    {
        PlaceTrap(TrapType.Slowdown, "Zone1");
    }

    public void SetTrapZone1OilLeak()
    {
        PlaceTrap(TrapType.OilLeak, "Zone1");
    }

    // Button methods for Zone 2
    public void SetTrapZone2SpeedBoost()
    {
        PlaceTrap(TrapType.SpeedBoost, "Zone2");
    }

    public void SetTrapZone2Slowdown()
    {
        PlaceTrap(TrapType.Slowdown, "Zone2");
    }

    public void SetTrapZone2OilLeak()
    {
        PlaceTrap(TrapType.OilLeak, "Zone2");
    }

    // Make this method public so it is accessible
    public void PlaceTrap(TrapType trapType, string zone)
    {
        GameData.AddTrap(new TrapData(trapType, zone));
    }

    public void StartRace()
    {
        SceneManager.LoadScene("Game");
    }
}
