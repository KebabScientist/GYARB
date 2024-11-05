using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleSelector : MonoBehaviour
{
    // Called when the "Select Bike" button is clicked
    public void SelectBike()
    {
        PlayerPrefs.SetString("SelectedVehicle", "Bike");
        LoadGameScene();
    }

    // Called when the "Select Car" button is clicked
    public void SelectCar()
    {
        PlayerPrefs.SetString("SelectedVehicle", "Car");
        LoadGameScene();
    }

    // Load the main game scene after selection
    private void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with the name of your gameplay scene
    }
}
