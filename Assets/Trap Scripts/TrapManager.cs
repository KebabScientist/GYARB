using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapManager : MonoBehaviour
{
    private TrapType selectedTrapTypeZone1;
    private TrapType selectedTrapTypeZone2;

    public void SetTrapZone1SpeedBoost()
    {
        selectedTrapTypeZone1 = TrapType.SpeedBoost;
    }

    public void SetTrapZone1Slowdown()
    {
        selectedTrapTypeZone1 = TrapType.Slowdown;
    }

    public void SetTrapZone1OilLeak()
    {
        selectedTrapTypeZone1 = TrapType.OilLeak;
    }

    public void SetTrapZone2SpeedBoost()
    {
        selectedTrapTypeZone2 = TrapType.SpeedBoost;
    }

    public void SetTrapZone2Slowdown()
    {
        selectedTrapTypeZone2 = TrapType.Slowdown;
    }

    public void SetTrapZone2OilLeak()
    {
        selectedTrapTypeZone2 = TrapType.OilLeak;
    }

    // Update this method to be public and to match the parameters
    public void PlaceTrap(TrapType trapType, string zone)
    {
        GameData.AddTrap(new TrapData(trapType, zone));
    }

    public void ConfirmTraps()
    {
        GameData.AddTrap(new TrapData(selectedTrapTypeZone1, "Zone1"));
        GameData.AddTrap(new TrapData(selectedTrapTypeZone2, "Zone2"));
        SceneManager.LoadScene("RaceScene");
    }
}
