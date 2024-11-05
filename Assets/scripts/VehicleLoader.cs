using UnityEngine;

public class VehicleLoader : MonoBehaviour
{
    // References to the bike and car models in the gameplay scene
    public GameObject bikeModel;
    public GameObject carModel;

    void Start()
    {
        // Retrieve the selected vehicle from PlayerPrefs
        string selectedVehicle = PlayerPrefs.GetString("SelectedVehicle", "Car"); // Defaults to "Car"

        // Activate the selected vehicle, deactivate the other
        if (selectedVehicle == "Bike")
        {
            bikeModel.SetActive(true);
            carModel.SetActive(false);
        }
        else
        {
            carModel.SetActive(true);
            bikeModel.SetActive(false);
        }
    }
}
